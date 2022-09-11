using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedsPlanner.Shared
{
    public class ActionItem
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string ActionType { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public double? Quantity { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public int? Water { get; set; }
        public int? Rate { get; set; }
        public string Application { get; set; }
        public bool? Status { get; set; }
    }
}
