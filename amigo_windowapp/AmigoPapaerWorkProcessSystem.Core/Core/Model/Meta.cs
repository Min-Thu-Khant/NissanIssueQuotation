using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Core
{
    public class Meta
    {
        private Double duration;

        public Double Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        private int total = 0;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        private int offset = 0;

        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        private int limit;

        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }
    }
}
