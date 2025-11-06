using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public class Nyerges : Kamion
    {
        public Nyerges(string r, string h, int tbir, int fogy) : base(r, h, tbir, fogy) { }

        public override int JarmuFaktor(Kezdo S) { return 25; }
        public override int JarmuFaktor(Gyakorlott S) { return 35; }
        public override int JarmuFaktor(Torzstag S) { return 40; }

        public override int maxBiras() { return teherbir * 3; }

    }
}
