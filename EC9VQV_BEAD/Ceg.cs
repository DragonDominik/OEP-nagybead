using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public class Ceg
    {
        public string cegnev { get; }

        public List<Fuvar> fuvarok { get; private set; }
        public List<Kamion> kamionok { get; private set; }
        public List<Sofor> soforok { get; private set; }

        public Ceg(string cegnev)
        {
            this.cegnev = cegnev;
            this.fuvarok = new List<Fuvar>();
            this.kamionok = new List<Kamion>();
            this.soforok = new List<Sofor>();
        }

        public void vasarolKamion(Kamion k)
        {
            kamionok.Add(k);
        }

        public void felveszSofor(Sofor s)
        {
            soforok.Add(s);
        }

        public void felveszFuvar(Fuvar f)
        {
            fuvarok.Add(f);
        }

        public Kamion Legkisebbmegfelelo(int teher)
        {
            int max = 0;
            Kamion? kamion = null;
            bool i = false;
            foreach (Kamion k in kamionok)
            {
                if (k.maxBiras() < teher) continue;
                int v = k.maxBiras();
                if (!i) { i = true; max = v; kamion = k; }
                else if (v > max) { max = v; kamion = k; }
            }
            if (!i) throw new Exception("Nincs megfelelő kamion");
            return kamion!;
        }

        public bool vanSzabad()
        {
            foreach (Kamion k in kamionok)
            {
                if (k.nincsFuvar())
                {
                    return true;
                }
            }
            return false;
        }

        public void eltavSofor(string jogositvany)
        {
            bool i = false;
            Sofor? sofor = null;
            foreach (Sofor s in soforok)
            {
                if (s.jogositvany == jogositvany) { i = true; sofor = s; break; } 
            }
            if (!i) throw new Exception("Nincs ilyen sofőr");
            if (sofor!.jarmu != null) throw new Exception("Épp fuvar alatt van");
            bool vanfuvar = false;
            foreach (Fuvar f in sofor!.fuvarok)
            {
                if (f.celido == null) { vanfuvar = true; break; }
            }
            if (vanfuvar) throw new Exception("Vannak fuvarjai");
            soforok.Remove(sofor);
        }

        public void eltavKamion(string rendszam)
        {
            bool i = false;
            Kamion? kamion = null;
            foreach (Kamion k in kamionok)
            {
                if (k.rendszam == rendszam) { i = true; kamion = k; break; }
            }
            if (!i) throw new Exception("Nincs ilyen kamion");
            if (kamion!.vezeto != null) throw new Exception("Épp használatban van");
            bool vanfuvar = false;
            foreach (Fuvar f in kamion!.fuvarok)
            {
                if (f.celido == null) { vanfuvar = true; break; }
            }
            if (vanfuvar) throw new Exception("Vannak fuvarjai");
            kamionok.Remove(kamion);
        }

        public int idoszakiNyer(DateTime mettol, DateTime meddig)
        {
            int osszes = 0;
            foreach (Fuvar fuvar in fuvarok)
            {
                if (fuvar.kezdoido == null || fuvar.celido == null) continue;
                if (fuvar.kezdoido.Value >= mettol && fuvar.celido.Value <= meddig)
                {
                    osszes += (fuvar.dij - ( (fuvar.tav/100) * fuvar.jarmu!.fogyasztas) - fuvar.soforBer());
                }
            }
            return osszes;
        }
    }
}
