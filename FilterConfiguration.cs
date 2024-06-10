using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DO
{
    internal class FilterConfiguration
    {
        public bool HideCompleted { get; set; } = false;
        public int CategoryId { get; set; } = 0;
        public string TxtFilterKeywords { get; set; } = string.Empty;
        public string sortOption { get; set; } = string.Empty;
    }
}
