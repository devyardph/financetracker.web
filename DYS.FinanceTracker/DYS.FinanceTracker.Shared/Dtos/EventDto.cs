using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class EventDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? AllDay { get; set; } = false;
        public string Color { get; set; } = "";
        public string TextColor { get; set; } = "#ffffff";
        public string ClassName { get; set; } = "bg-primary";
        public string Action { get; set; }
    }
}
