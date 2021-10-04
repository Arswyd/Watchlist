﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class HeaderModel
    {
        public int ID { get; set; }
        public string ListType { get; set; }
        public string ListGroup { get; set; }
        public int SortOrder { get; set; }
        public int Count { get; set; }
    }
}