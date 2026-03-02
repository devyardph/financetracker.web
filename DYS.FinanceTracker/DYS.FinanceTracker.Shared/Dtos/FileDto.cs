using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class FileDto
    {
        public byte[]? Content { get; set; }
        public string FileExtension { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
    }
}
