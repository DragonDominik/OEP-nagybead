using EC9VQV_BEAD;

namespace TEST_BEAD;

[TestClass]
public class SoforTeszt
{
    [TestMethod]
    public void KezdoSoforFaktorTeszt()
    {
        Fulkes kamion = new Fulkes("ABC-123", "Budapest", 1000, 20);
        Kezdo sofor = new Kezdo("Teszt Sofőr", "K123");

        sofor.Vezet(kamion, "Budapest");
        int faktor = sofor.SoforFaktor(kamion);

        Assert.AreEqual(20, faktor);
    }

    [TestMethod]
    public void GyakorlottSoforFaktorTeszt()
    {
        Nyerges kamion = new Nyerges("ABC-123", "Budapest", 1000, 20);
        Gyakorlott sofor = new Gyakorlott("Teszt Sofőr", "K123");

        sofor.Vezet(kamion, "Budapest");
        int faktor = sofor.SoforFaktor(kamion);

        Assert.AreEqual(35, faktor);
    }

    [TestMethod]
    public void TorzstagSoforFaktorTeszt()
    {
        Fulkes kamion = new Fulkes("ABC-123", "Budapest", 1000, 20);
        Torzstag sofor = new Torzstag("Teszt Sofőr", "K123");

        sofor.Vezet(kamion, "Budapest");
        int faktor = sofor.SoforFaktor(kamion);

        Assert.AreEqual(40, faktor);
    }

    [TestMethod]
    public void elszamolasTeszt()
    {
        Fulkes kamion = new Fulkes("ABC-123", "Budapest", 1000, 20);
        Torzstag sofor = new Torzstag("Teszt Sofőr", "K123");

        sofor.Vezet(kamion, "Budapest");
        int plusszut = sofor.plusszut;
        Assert.IsTrue(plusszut > 0);

        sofor.elszamolPlussz();
        Assert.AreEqual(0, sofor.plusszut);
    }

    [TestMethod]
    public void Sofor_ujfuvar()
    {
        Torzstag sofor = new Torzstag("Zsolt", "TOT931");
        Fuvar fuvar = new Fuvar("Győr", "Budapest", 120, 800, 150000);
        Fuvar fuvar1 = new Fuvar("Budapest", "Szeged", 420, 500, 150000);
        Fuvar fuvar2 = new Fuvar("Szeged", "Kecskemét", 320, 300, 150000);

        fuvar.SoforValaszt(sofor);
        Assert.AreEqual(1, sofor.fuvarok.Count);
        fuvar1.SoforValaszt(sofor);
        Assert.AreEqual(2, sofor.fuvarok.Count);
        fuvar2.SoforValaszt(sofor);
        Assert.AreEqual(3, sofor.fuvarok.Count);
    }


}
