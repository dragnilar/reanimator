﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using TableHeader = Hellgate.ExcelFile.TableHeader;

namespace Hellgate.Excel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class InitDb
    {
        TableHeader header;
        public Int32 skip;//bool
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string criteria;
        public Int32 rangeLow;
        public Int32 rangeHigh;
        public float numMin;
        public float numMax;
        public float numInit;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string featKnob;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string featMin;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string featMax;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string featInit;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string numKnob;
    }
}
