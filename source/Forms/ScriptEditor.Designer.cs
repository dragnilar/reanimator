﻿namespace Reanimator.Forms
{
    partial class ScriptEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.newButton = new System.Windows.Forms.Button();
            this.applyCheckedButton = new System.Windows.Forms.Button();
            this.applyCurrentButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.availableCombo = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox);
            this.groupBox1.Location = new System.Drawing.Point(237, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 538);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor";
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.AcceptsTab = true;
            this.textBox.AllowDrop = true;
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(7, 20);
            this.textBox.MaxLength = 1000000;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(522, 512);
            this.textBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.newButton);
            this.groupBox2.Controls.Add(this.applyCheckedButton);
            this.groupBox2.Controls.Add(this.applyCurrentButton);
            this.groupBox2.Controls.Add(this.saveButton);
            this.groupBox2.Controls.Add(this.availableCombo);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 538);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scripts";
            // 
            // newButton
            // 
            this.newButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newButton.Location = new System.Drawing.Point(7, 484);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(96, 23);
            this.newButton.TabIndex = 8;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // applyCheckedButton
            // 
            this.applyCheckedButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.applyCheckedButton.Location = new System.Drawing.Point(117, 509);
            this.applyCheckedButton.Name = "applyCheckedButton";
            this.applyCheckedButton.Size = new System.Drawing.Size(96, 23);
            this.applyCheckedButton.TabIndex = 6;
            this.applyCheckedButton.Text = "Apply Checked";
            this.applyCheckedButton.UseVisualStyleBackColor = true;
            this.applyCheckedButton.Click += new System.EventHandler(this.applyCheckedButton_Click);
            // 
            // applyCurrentButton
            // 
            this.applyCurrentButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.applyCurrentButton.Location = new System.Drawing.Point(117, 484);
            this.applyCurrentButton.Name = "applyCurrentButton";
            this.applyCurrentButton.Size = new System.Drawing.Size(96, 23);
            this.applyCurrentButton.TabIndex = 5;
            this.applyCurrentButton.Text = "Apply Current";
            this.applyCurrentButton.UseVisualStyleBackColor = true;
            this.applyCurrentButton.Click += new System.EventHandler(this.applyCurrentButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(6, 509);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // availableCombo
            // 
            this.availableCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.availableCombo.FormattingEnabled = true;
            this.availableCombo.Location = new System.Drawing.Point(7, 20);
            this.availableCombo.Name = "availableCombo";
            this.availableCombo.Size = new System.Drawing.Size(206, 454);
            this.availableCombo.TabIndex = 0;
            this.availableCombo.SelectedIndexChanged += new System.EventHandler(this.availableCombo_SelectedIndexChanged);
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ScriptEditor";
            this.Text = "Script Editor";
            this.Load += new System.EventHandler(this.ScriptEditor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScriptEditor_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button applyCurrentButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button applyCheckedButton;
        private System.Windows.Forms.CheckedListBox availableCombo;
    }
}