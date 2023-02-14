using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    internal class Donto
    {
        public RomaiSorszam Ssz { get; set; }
        public DateTime Datum { get; set; }
        public string Gyoztes { get; set; }
        public (int GY, int V) Eredmeny { get; set; }
        public string Vesztes { get; set; }
        public string Helyszin { get; set; }
        public string Varos { get; set; }
        public string Allam { get; set; }
        public int Nezoszam { get; set; }

        public Donto(string r)
        {
            string[] v = r.Split(';');
            Ssz = new RomaiSorszam(v[0]);
            Datum = DateTime.Parse(v[1]);
            Gyoztes = v[2];
            string[] gyvp = v[3].Split('-');
            Eredmeny = (int.Parse(gyvp[0]), int.Parse(gyvp[1]));
            Vesztes = v[4];
            Helyszin = v[5];
            string[] vap= v[6].Split(", ");
            Varos = vap[0];
            Allam = vap[1];
            Nezoszam = int.Parse(v[7]);
        }
    }
}
