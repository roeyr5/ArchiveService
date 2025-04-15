using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ArchiveData.Models
{
    public class ArchiveDataPacket
    {
        public Dictionary<string, string> UavData { get; set; }
        public DateTime DateTime { get; set; }

    }
}
