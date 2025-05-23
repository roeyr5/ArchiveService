﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveData.Models
{
    public class ArchiveMultiRequestDto
    {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int[] UavNumbers { get; set; }
            public string Communication { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string[] ParameterNames { get; set; }

    }
}
