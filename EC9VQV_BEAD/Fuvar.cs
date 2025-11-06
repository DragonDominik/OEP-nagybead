using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public class Fuvar
    {
        public string kezdo { get; }
        public string cel { get; }
        public int tav { get; private set; }
        public int teher { get; }
        public int dij { get; }
        public DateTime? kezdoido { get; private set; }
        public DateTime? celido { get; private set; }

        public Sofor? vezeto { get; private set; }
        public Kamion? jarmu { get; private set; }

        public Fuvar(string k, string c, int ta, int te, int d)
        {
            this.kezdo = k;
            this.cel = c;
            this.tav = ta;
            this.teher = te;
            this.dij = d;

            this.jarmu = null;
            this.vezeto = null;
            this.kezdoido = null;
            this.celido = null;
        }

        public void SoforValaszt(Sofor s)
        {
            vezeto = s;
            vezeto.addFuvarok(this);
        }

        public void JarmuValaszt(Kamion k)
        {
            jarmu = k;
            jarmu.addFuvarok(this);
        }

        public void RogzitIndulas()
        {
            if (jarmu == null) throw new Exception("Nincs kiválasztott jármű");
            if (jarmu.helyzet != kezdo) throw new Exception("Nincs a kezdőponton");
            kezdoido = DateTime.Now;
            jarmu.rakomanyAll(true);
        }

        public void RogzitErkezes()
        {
            if (jarmu == null) throw new Exception("Nincs kiválasztott jármű");
            if (jarmu.helyzet != cel) throw new Exception("Nincs a célponton");
            if (jarmu!.vanRakomany == false) throw new Exception("Nincs nála rakomány");
            celido = DateTime.Now;
            jarmu.rakomanyAll(false);
            jarmu.allapotCsere(Allapot.SZABAD);
            vezeto!.kiszall();
            tav += vezeto.plusszut;
            vezeto.elszamolPlussz();
        }

        public int soforBer()
        {
            if (celido == null) throw new Exception("A fuvar még elvégezetlen");
            if (jarmu == null) throw new Exception("Nincs jármű kiválasztva");
            return tav * vezeto!.SoforFaktor(jarmu!);
        }
    }
}
