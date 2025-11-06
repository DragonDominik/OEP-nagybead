using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EC9VQV_BEAD
{
    internal class Program //adatok felpopulálása txtből
    {
        static void Main(string[] args)
        {
            Ceg ceg = new Ceg("TransLogisztika Kft.");

            string fajlUt = args.Length > 0 ? args[0] : "adatok.txt";

            if (!File.Exists(fajlUt))
            {
                Console.WriteLine($"Nem található a fájl: {fajlUt}");
                return;
            }

            foreach (var sor in File.ReadAllLines(fajlUt))
            {
                if (string.IsNullOrWhiteSpace(sor)) continue;

                if (sor.StartsWith("KAMION:"))
                {
                    var adatok = sor.Split(':')[1].Split(';');
                    Kamion kamion = adatok[4] == "FULKES"
                        ? new Fulkes(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3]))
                        : new Nyerges(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3]));
                    ceg.vasarolKamion(kamion);
                }
                else if (sor.StartsWith("SOFOR:"))
                {
                    var adatok = sor.Split(':')[1].Split(';');
                    Sofor sofor = adatok[2] switch
                    {
                        "KEZDO" => new Kezdo(adatok[0], adatok[1]),
                        "GYAKORLOTT" => new Gyakorlott(adatok[0], adatok[1]),
                        "TORZSTAG" => new Torzstag(adatok[0], adatok[1]),
                        _ => throw new Exception("Ismeretlen sofőrtípus")
                    };
                    ceg.felveszSofor(sofor);
                }
                else if (sor.StartsWith("FUVAR:"))
                {
                    var adatok = sor.Split(':')[1].Split(';');
                    Fuvar fuvar = new Fuvar(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3]), int.Parse(adatok[4]));
                    ceg.felveszFuvar(fuvar);
                }
                else if (sor.StartsWith("HOZZARENDELES:"))
                {
                    var adatok = sor.Split(':')[1].Split(';');
                    int fuvarId = int.Parse(adatok[0]);
                    var fuvar = ceg.fuvarok[fuvarId - 1];
                    var kamion = ceg.kamionok.First(k => k.rendszam == adatok[1]);
                    var sofor = ceg.soforok.First(s => s.jogositvany == adatok[2]);

                    fuvar.JarmuValaszt(kamion);
                    fuvar.SoforValaszt(sofor);
                }
            }

            Console.WriteLine("Adatok betöltve sikeresen.");
        }
    }
}