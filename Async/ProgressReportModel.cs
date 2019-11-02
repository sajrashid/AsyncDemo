using System;
using System.Collections.Generic;
using System.Text;

namespace Async
{
    public class ProgressReportModel
    {
        public int PercentComplete { get; set; }

        public List<string> Downloaded { get; } = new List<string>();
    }
}
