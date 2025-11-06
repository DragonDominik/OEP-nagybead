using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public class Fulkes : Kamion
    {
        public Fulkes(string r, string h, int tbir, int fogy) : base(r, h, tbir, fogy) { }

        public override int JarmuFaktor(Kezdo S) { return 20; }
        public override int JarmuFaktor(Gyakorlott S) { return 30; }
        public override int JarmuFaktor(Torzstag S) { return 40; }

        public override int maxBiras() { return teherbir * 2; }

    }
}
