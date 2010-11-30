﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Hellgate;
using Reanimator.Properties;

namespace Reanimator.Forms
{
    partial class FileExplorer
    {
        private const String ReanimatorIndex = "sp_hellgate_1337";

        private static readonly Icon[] Icons = { Resources.GenericDocument, Resources.Folder, Resources.FolderOpen, Resources.XMLFile, Resources.AudioFile, Resources.MediaFile };
        private enum IconIndex
        {
            GenericDocument,
            Folder,
            FolderOpen,
            XmlFile,
            AudioFile,
            MediaFile
        }

        private static readonly Color BackupColor = Color.IndianRed;
        private static readonly Color NoEditColor = Color.DimGray;
        private static readonly Color BaseColor = Color.Black;

        private class NodeObject
        {
            public IndexFile Index;
            public IndexFile.FileEntry FileEntry;
            public bool IsFolder;
            public bool IsBackup;
            public bool CanEdit;
            public bool CanCookWith;
            public bool IsUncookedVersion;
            public List<NodeObject> Siblings;

            public void AddSibling(NodeObject siblingNodeObject)
            {
                if (Siblings == null)
                {
                    Siblings = new List<NodeObject>();
                }

                Siblings.Add(siblingNodeObject);
            }
        }

        private class NodeSorter : IComparer
        {
            public int Compare(Object objX, Object objY)
            {
                TreeNode treeNodeX = (TreeNode)objX;
                TreeNode treeNodeY = (TreeNode)objY;

                NodeObject nodeObjectX = (NodeObject)treeNodeX.Tag;
                NodeObject nodeObjectY = (NodeObject)treeNodeY.Tag;

                if (nodeObjectX != null && nodeObjectY != null)
                {
                    if (nodeObjectX.IsFolder && !nodeObjectY.IsFolder) return -1;
                    if (!nodeObjectX.IsFolder && nodeObjectY.IsFolder) return 1;
                }

                return treeNodeX.Text.CompareTo(treeNodeY.Text);
            }
        }

        private class ExtractPackPatchArgs
        {
            public bool KeepStructure;
            public bool PatchFiles;
            public String RootDir;
            public List<TreeNode> CheckedNodes;
            public IndexFile PackIndex;
        }

        /// <summary>
        /// Loop over all file entries and generate tree nodes.
        /// </summary>
        private void _GenerateFileTree()
        {
            foreach (IndexFile.FileEntry fileEntry in _fileManager.FileEntries.Values)
            {
                NodeObject nodeObject = new NodeObject { Index = fileEntry.Index, FileEntry = fileEntry };
                String[] nodeKeys = fileEntry.DirectoryStringWithoutBackup.Split('\\');
                TreeNode treeNode = null;


                // set up folders and get applicable root folder
                foreach (String nodeKey in nodeKeys.Where(nodeKey => !String.IsNullOrEmpty(nodeKey)))
                {
                    if (treeNode == null)
                    {
                        treeNode = _files_fileTreeView.Nodes[nodeKey] ?? _files_fileTreeView.Nodes.Add(nodeKey, nodeKey);
                    }
                    else
                    {
                        treeNode = treeNode.Nodes[nodeKey] ?? treeNode.Nodes.Add(nodeKey, nodeKey);
                    }
                }
                Debug.Assert(treeNode != null);


                // need to have canEdit check before we update the node below or it'll be false for newer versions);
                if (fileEntry.FileNameString.EndsWith(XmlCookedFile.FileExtention))
                {
                    // we can't edit all .xml.cooked yet...
                    if (nodeKeys.Contains("skills") ||
                        nodeKeys.Contains("ai") ||
                        (nodeKeys.Contains("states") && !nodeKeys.Contains("particles")) ||
                        nodeKeys.Contains("effects") ||
                        (nodeKeys.Contains("background") &&
                         (fileEntry.FileNameString.Contains("layout")
                        /* todo: not parsing 100% || currFile.FileNameString.Contains("path")*/)) ||
                        (nodeKeys.Contains("materials") && !nodeKeys.Contains("textures")))
                    {
                        nodeObject.CanEdit = true;
                        nodeObject.CanCookWith = true;
                    }
                }
                else if (fileEntry.FileNameString.EndsWith(ExcelFile.FileExtention) ||
                         fileEntry.FileNameString.EndsWith(StringsFile.FileExtention) ||
                         fileEntry.FileNameString.EndsWith("txt"))
                {
                    nodeObject.CanEdit = true;
                }


                // our new node
                TreeNode node = treeNode.Nodes.Add(fileEntry.RelativeFullPathWithoutBackup, fileEntry.FileNameString);
                _AssignIcons(node);


                // if we can cook with it, then check if the uncooked version is present
                if (nodeObject.CanCookWith)
                {
                    // sanity check
                    String nodeFullPath = node.FullPath;
                    Debug.Assert(nodeFullPath.EndsWith(".cooked"));

                    String uncookedDataPath = nodeFullPath.Replace(".cooked", "");
                    String uncookedFilePath = Path.Combine(Config.HglDir, uncookedDataPath);
                    if (File.Exists(uncookedFilePath))
                    {
                        String uncookedFileName = Path.GetFileName(uncookedFilePath);
                        TreeNode uncookedNode = node.Nodes.Add(uncookedDataPath, uncookedFileName);
                        _AssignIcons(uncookedNode);

                        NodeObject uncookedNodeObject = new NodeObject
                        {
                            IsUncookedVersion = true,
                            CanCookWith = true,
                            CanEdit = true
                        };
                        uncookedNode.Tag = uncookedNodeObject;
                    }
                }


                // final nodeObject setups
                if (nodeObject.IsBackup)
                {
                    node.ForeColor = BackupColor;
                }
                else if (!nodeObject.CanEdit)
                {
                    node.ForeColor = NoEditColor;
                }
                node.Tag = nodeObject;
            }


            // aesthetics etc
            foreach (TreeNode treeNode in _files_fileTreeView.Nodes)
            {
                if (treeNode.Index == 0)
                {
                    _files_fileTreeView.SelectedNode = treeNode;
                }

                treeNode.Expand();
                _FlagFolderNodes(treeNode);
            }
        }

        /// <summary>
        /// Sets the ImageIndex in a TreeNode depending on its FullPath "file extension".
        /// </summary>
        /// <param name="treeNode">The TreeNode to set icons to.</param>
        private static void _AssignIcons(TreeNode treeNode)
        {
            String nodePath = treeNode.FullPath;

            if (nodePath.EndsWith(XmlCookedFile.FileExtention) || nodePath.EndsWith(".xml"))
            {
                treeNode.ImageIndex = (int)IconIndex.XmlFile;
            }
            else if (nodePath.EndsWith("mp2") || nodePath.EndsWith("ogg"))
            {
                treeNode.ImageIndex = (int)IconIndex.AudioFile;
            }
            else if (nodePath.EndsWith("bik"))
            {
                treeNode.ImageIndex = (int)IconIndex.MediaFile;
            }

            treeNode.SelectedImageIndex = treeNode.ImageIndex;
        }

        /// <summary>
        /// Finds all folder nodes by recursivly searching for nodes <i>without an associated NodeObject</i>
        /// and adds a default NodeObject flagged as a folder.
        /// </summary>
        /// <param name="treeNode">Root Tree Node.</param>
        private static void _FlagFolderNodes(TreeNode treeNode)
        {
            if (treeNode.Nodes.Count <= 0) return;

            if (treeNode.Tag == null)
            {
                treeNode.Tag = new NodeObject { IsFolder = true };
                treeNode.ImageIndex = (int)IconIndex.Folder;
                treeNode.SelectedImageIndex = treeNode.ImageIndex;
            }

            foreach (TreeNode childNode in treeNode.Nodes)
            {
                _FlagFolderNodes(childNode);
            }
        }

        /// <summary>
        /// Adds all checked nodes from a TreeNodeCollection to a Collection of TreeNodes.<br />
        /// If the node is a folder, it is not added; instead its children are checked.
        /// </summary>
        /// <param name="nodes">Root TreeNodeCollection to recursivly search.</param>
        /// <param name="checkedNodes">The Collection to add checked nodes to.</param>
        /// <returns>The total number of checked nodes.</returns>
        private static int _GetCheckedNodes(TreeNodeCollection nodes, ICollection<TreeNode> checkedNodes)
        {
            Debug.Assert(checkedNodes != null);

            foreach (TreeNode childNode in nodes)
            {
                // check children
                if (childNode.Nodes.Count > 0)
                {
                    _GetCheckedNodes(childNode.Nodes, checkedNodes);

                    // don't want folders
                    NodeObject nodeObject = (NodeObject)childNode.Tag;
                    if (nodeObject.IsFolder) continue;
                }

                if (!childNode.Checked) continue;

                checkedNodes.Add(childNode);
            }

            return checkedNodes.Count;
        }
    }
}