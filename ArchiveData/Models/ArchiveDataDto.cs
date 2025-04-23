using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchiveData.Models;

namespace ArchiveData.Models
{
    public class ArchiveDataDto
    {
        public List<ArchiveDataPacket> ArchiveDataPackets { get; set; }
        public int UavNumber { get; set; }
        public string Communication { get; set; }
        public string ParameterName { get; set; }

    }
    public class MultiArchiveDataDto
    {
        public List<ArchiveDataPackets> ArchiveDataPackets { get; set; }
        public int UavNumber { get; set; }
        public string Communication { get; set; }

    }
}
