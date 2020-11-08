using AmigoPaperWorkProcessSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Core.Model
{
    public class Validate
    {
        public string Name { get; set; }

        public Utility.DataType Type { get; set; }

        public bool Edit { get; set; }

        public bool Require { get; set; }

        public string Initial { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public string Data1 { get; set; }

        public string Data2 { get; set; }
    }
}
