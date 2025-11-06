using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public abstract class Kamion
    {
        public string rendszam { get; }
        public string helyzet { get; private set; }
        public Allapot allapot { get; private set; }
        protected int teherbir;
        public int fogyasztas { get; }
        public bool vanRakomany { get; private set; }

        public List<Fuvar> fuvarok { get; private set; }

        public Sofor? vezeto { get; private set; }

        public Kamion(string r, string h, int tbir, int fogy)
        {
            this.rendszam = r;
            this.helyzet = h;
            this.allapot = Allapot.SZABAD;
            this.teherbir = tbir;
            this.fogyasztas = fogy;
            this.fuvarok = new List<Fuvar>();
            this.vezeto = null;
        }

        public bool nincsFuvar()
        {
            return fuvarok.Count == 0;
        }

        public void allapotCsere(Allapot a)
        {
            this.allapot = a;
        }

        public void vezetoBeall(Sofor? s)
        {
            this.vezeto = s;
        }

        public void helyzetBeall(String hely)
        {
            this.helyzet = hely;
        }

        public void rakomanyAll(bool all)
        {
            if (all == vanRakomany) throw new Exception("rakományra nem lehet rakományt rakni és üres autóból rakományt kivenni");
            this.vanRakomany = all;
        }

        public abstract int JarmuFaktor(Kezdo S);
        public abstract int JarmuFaktor(Gyakorlott S);
        public abstract int JarmuFaktor(Torzstag S);

        public abstract int maxBiras();

        public void addFuvarok(Fuvar fuvar)
        {
            fuvarok.Add(fuvar);
        }
    }
}
