using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EC9VQV_BEAD
{
    public abstract class Sofor
    {
        public string nev {  get; private set; }
        public string jogositvany { get; }
        public int plusszut { get; private set; }

        public Kamion? jarmu { get; private set; }

        public List<Fuvar> fuvarok { get; private set; }

        public Sofor(string n, string jog)
        {
            this.nev = n;
            this.jogositvany = jog;
            this.plusszut = 0;
            this.fuvarok = new List<Fuvar>();
            jarmu = null;
        }

        public void elszamolPlussz()
        {
            this.plusszut = 0;
        }

        public abstract int SoforFaktor(Kamion k);

        public void kiszall()
        {
            if (jarmu == null) throw new Exception("Nincs jelenleg járműben");
            if (jarmu.allapot != Allapot.SZABAD && jarmu.allapot != Allapot.VARAKOZIK) throw new Exception("Nem szállhat ki fuvar közben");
            jarmu.vezetoBeall(null);
            jarmu = null;
        }

        public void Vezet(Kamion k, string hova)
        {
            if (jarmu != null && jarmu != k) throw new Exception("Már más kamionban van");
            jarmu = k;
            if (jarmu.vezeto is not null && jarmu.vezeto != this) throw new Exception("A jármű már foglalt");
            jarmu.vezetoBeall(this);
            if (jarmu.vanRakomany)
            {
                jarmu.allapotCsere(Allapot.FUVART_SZALLIT);
            }
            else
            {
                jarmu.allapotCsere(Allapot.FUVARERT_MEGY);
                plusszut += new Random().Next(50, 201); //kép pont közötti km kiszámolás nincs implementálva
            }
            jarmu.helyzetBeall(hova);
            jarmu.allapotCsere(Allapot.VARAKOZIK);
        }

        public int idoszakiBer(DateTime mettol, DateTime meddig)
        {
            int osszes = 0;
            foreach(Fuvar fuvar in fuvarok){
                if (fuvar.kezdoido == null || fuvar.celido == null) continue;
                if (fuvar.kezdoido.Value >= mettol && fuvar.celido.Value <= meddig)
                {
                    osszes += fuvar.soforBer();
                }
            }
            return osszes;
        }

        public void addFuvarok(Fuvar fuvar)
        {
            fuvarok.Add(fuvar);
        }

    }
}
