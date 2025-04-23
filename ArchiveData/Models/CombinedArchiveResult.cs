using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveData.Models
{
    public class CombinedArchiveResult
    {
        public List<ArchiveDataPacket> DataPackets { get; set; }
        public int TotalCount { get; set; }
    }
}
