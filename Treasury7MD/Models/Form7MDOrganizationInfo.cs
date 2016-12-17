﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Treasury7MD.Models
{
    public class Form7MDOrganizationInfo
    {
        public string OrganizationName { get; set; }
        public string Territory { get; set; }
        public string EDRPOU { get; set; }
        public string KOATUU { get; set; }
        public string OPFG { get; set; }
        public string KOPFG { get; set; }
        public string VKVKDBCode { get; set; }
        public string VKVKDBName { get; set; }
        public string PKVKDBCode { get; set; }
        public string PKVKDBName { get; set; }
        public string TVKVKMBCode { get; set; }
        public string TVKVKMBName { get; set; }
        public string PKVKMBCode { get; set; }
        public string PKVKMBName { get; set; }
        public string OPFGName { get; set; }
    }
}
