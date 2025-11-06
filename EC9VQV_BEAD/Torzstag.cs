using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public class Torzstag : Sofor
    {
        public Torzstag(string n, string jog) : base(n, jog) { }

        public override int SoforFaktor(Kamion k)
        {
            if (k == null) throw new Exception("Nem volt jármű");
            return k!.JarmuFaktor(this);
        }
    }
}
