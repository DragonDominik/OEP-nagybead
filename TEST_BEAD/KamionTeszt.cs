using EC9VQV_BEAD;

namespace TEST_BEAD;

[TestClass]
public class KamionTesztr
{
    [TestMethod]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var kamion = new Fulkes("TEST-001", "Budapest", 1000, 15);

        Assert.AreEqual("TEST-001", kamion.rendszam);
        Assert.AreEqual("Budapest", kamion.helyzet);
        Assert.AreEqual(Allapot.SZABAD, kamion.allapot);
        Assert.AreEqual(1000 * 2, kamion.maxBiras());
        Assert.AreEqual(15, kamion.fogyasztas);
        Assert.IsFalse(kamion.vanRakomany);
        Assert.IsNull(kamion.vezeto);
    }

    [TestMethod]
    public void Fulkes_maxBirasTeszt()
    {
        Fulkes fulkes = new Fulkes("FUL-001", "Szeged", 1500, 25);

        int max = fulkes.maxBiras();

        Assert.AreEqual(3000, max);
    }

    [TestMethod]
    public void Nyerges_maxBirasTeszt()
    {
        Nyerges nyerges = new Nyerges("FUL-001", "Szeged", 1500, 25);

        int max = nyerges.maxBiras();

        Assert.AreEqual(4500, max);
    }

    [TestMethod]
    public void Kamion_ujfuvar()
    {
        Fulkes kamion = new Fulkes("TEST-001", "Gy?r", 1000, 15);
        Fuvar fuvar = new Fuvar("Gy?r", "Budapest", 120, 800, 150000);
        Fuvar fuvar1 = new Fuvar("Budapest", "Szeged", 420, 500, 150000);
        Fuvar fuvar2 = new Fuvar("Szeged", "Kecskemét", 320, 300, 150000);

        fuvar.JarmuValaszt(kamion);
        Assert.AreEqual(1, kamion.fuvarok.Count);
        fuvar1.JarmuValaszt(kamion);
        Assert.AreEqual(2, kamion.fuvarok.Count);
        fuvar2.JarmuValaszt(kamion);
        Assert.AreEqual(3, kamion.fuvarok.Count);
    }

    [TestMethod]
    public void vezetoBeallTeszt()
    {
        var kamion = new Fulkes("TEST-003", "Budapest", 1000, 15);
        var sofor = new Kezdo("Teszt", "K123");

        kamion.vezetoBeall(sofor);

        Assert.AreEqual(sofor, kamion.vezeto);
    }

    [TestMethod]
    public void helyzetBeallTeszt()
    {
        var kamion = new Fulkes("TEST-004", "Budapest", 1000, 15);

        kamion.helyzetBeall("Debrecen");

        Assert.AreEqual("Debrecen", kamion.helyzet);
    }

    [TestMethod]
    public void rakomanyAllTeszt()
    {
        var kamion = new Fulkes("TEST-005", "Budapest", 1000, 15);

        kamion.rakomanyAll(true);
        Assert.IsTrue(kamion.vanRakomany);

        kamion.rakomanyAll(false);
        Assert.IsFalse(kamion.vanRakomany);
    }

    [TestMethod]
    public void allapotCsereTeszt()
    {
        var kamion = new Fulkes("TEST-006", "Budapest", 1000, 15);

        kamion.allapotCsere(Allapot.FUVART_SZALLIT);
        Assert.AreEqual(Allapot.FUVART_SZALLIT, kamion.allapot);
    }
}
