using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iotdustbin.Models
{
    public class veriler
    {
        public int id { get; set; }
        public float doluluk { get; set; }
        public float sicaklik { get; set; }
        public string atesdurumu { get; set; }
        public string gazdurumu { get; set; }
        public int fan { get; set; }
        public int buzzer { get; set; }
        public int kapakacma { get; set; }
    }
}
