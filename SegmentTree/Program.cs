﻿using System.Collections.Generic;

namespace SegmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentTree tree = new SegmentTree();
            tree.Build(new List<int> { 1, 3, 5, 7, 9, 11 });
        }
    }
}
