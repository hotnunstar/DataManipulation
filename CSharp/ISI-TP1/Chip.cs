using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISI_TP1
{

    public class Vendor
    {
        public string Name { get; set; }
        public List<Chip> Chips { get; set; }
    }
    public class Chip
    {
        public string Product { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal ProcessSize { get; set; }
        public decimal TDP { get; set; }
        public decimal DieSize { get; set; }
        public decimal Transistors { get; set; }
        public decimal Frequency { get; set; }
        public string Foundry { get; set; }
        public decimal FP16 { get; set; }
        public decimal FP32 { get; set; }
        public decimal FP64 { get; set; }
    }


}
