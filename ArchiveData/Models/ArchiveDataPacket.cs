using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ArchiveData.Models
{
    public class ArchiveDataPacket
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }
        public DateTime DateTime { get; set; }
        public int UavNumber { get; set; }

    }
    public class ArchiveDataPackets
    {
        public Dictionary<string, string> Parameters { get; set; }
        public DateTime DateTime { get; set; }
        public int UavNumber { get; set; }
    }
}
