﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRex.MPS.Model.Configuration
{
    public class AppSettings
    {
        public string AppName { get; set; }

        public DataBaseSettings DataBaseSettings { get; set; }
    }
}
