using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoQusApi.Models
{
    public class FoQusItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }
    }
}
