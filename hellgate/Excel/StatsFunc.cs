﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using TableHeader = Hellgate.ExcelFile.TableHeader;

namespace Hellgate.Excel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class StatsFunc
    {
        TableHeader header;
        public Int32 target;
        public Int32 app;
        public Int32 controlUnit;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] undefined1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
        public string formula;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] undefined2;
    }
}
