using EC9VQV_BEAD;

namespace TEST_BEAD;

[TestClass]
public class CegTeszt
{
    private Ceg ceg = null!;
    private Kamion kamion = null!;
    private Sofor sofor = null!;
    private Sofor sofor2 = null!;
    private Fuvar fuvar = null!;

    [TestInitialize]
    public void Initialize()
    {
        ceg = new Ceg("Teszt Kft.");
        kamion = new Fulkes("TEST-001", "Budapest", 1000, 15);
        sofor = new Kezdo("Teszt Sofőr", "K123");
        sofor2 = new Kezdo("Teszt Sofőr", "L123");
        fuvar = new Fuvar("Budapest", "Debrecen", 200, 800, 150000);
    }

    [TestMethod]
    public void KonstruktorTeszt()
    {
        Assert.AreEqual("Teszt Kft.", ceg.cegnev);
        Assert.AreEqual(0, ceg.fuvarok.Count);
        Assert.AreEqual(0, ceg.kamionok.Count);
        Assert.AreEqual(0, ceg.soforok.Count);
    }

    [TestMethod]
    public void vasarolKamionTeszt()
    {
        ceg.vasarolKamion(kamion);
        Assert.AreEqual(1, ceg.kamionok.Count);
        Assert.AreEqual(kamion, ceg.kamionok[0]);
    }

    [TestMethod]
    public void felveszSoforTeszt()
    {
        ceg.felveszSofor(sofor);
        Assert.AreEqual(1, ceg.soforok.Count);
        Assert.AreEqual(sofor, ceg.soforok[0]);
    }

    [TestMethod]
    public void felveszFuvarTeszt()
    {
        ceg.felveszFuvar(fuvar);
        Assert.AreEqual(1, ceg.fuvarok.Count);
        Assert.AreEqual(fuvar, ceg.fuvarok[0]);
    }

    [TestMethod]
    public void LegkisebbmegfeleloTeszt()
    {
        var kamion1 = new Fulkes("K1", "Bp", 1000, 15);
        var kamion2 = new Nyerges("K2", "Bp", 2000, 20);
        ceg.vasarolKamion(kamion1);
        ceg.vasarolKamion(kamion2);

        var result = ceg.Legkisebbmegfelelo(1500);
        Assert.AreEqual(kamion2, result);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void LegkisebbmegfeleloHibaTeszt()
    {
        ceg.vasarolKamion(new Fulkes("K1", "Bp", 1000, 15));
        ceg.Legkisebbmegfelelo(3000); //hiba mert nincs megfelelő
    }

    [TestMethod]
    public void vanSzabadTeszt()
    {
        ceg.vasarolKamion(kamion);
        Assert.IsTrue(ceg.vanSzabad());
    }

    [TestMethod]
    public void eltavSoforTeszt()
    {
        ceg.felveszSofor(sofor);
        ceg.eltavSofor(sofor.jogositvany);
        Assert.AreEqual(0, ceg.soforok.Count);
        ceg.felveszSofor(sofor); // + Teszt
        ceg.felveszSofor(sofor2);
        ceg.eltavSofor(sofor2.jogositvany);
        Assert.AreEqual(1, ceg.soforok.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void eltavSoforFuvarralHibaTeszt()
    {
        ceg.felveszSofor(sofor);
        ceg.felveszFuvar(fuvar);
        fuvar.SoforValaszt(sofor);
        ceg.eltavSofor(sofor.jogositvany);
    }

    [TestMethod]
    public void idoszakiNyerTeszt()
    {
        ceg.vasarolKamion(kamion);
        ceg.felveszSofor(sofor);
        ceg.felveszFuvar(fuvar);

        fuvar.JarmuValaszt(kamion);
        fuvar.SoforValaszt(sofor);
        sofor.Vezet(kamion, "Budapest");
        fuvar.RogzitIndulas();
        sofor.Vezet(kamion, "Debrecen");
        fuvar.RogzitErkezes();

        int teszttav = fuvar.tav;
        Assert.AreNotEqual(200, teszttav); //teszt hogy az extra táv hozzákerült e

        int nyereseg = ceg.idoszakiNyer(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
        int expected = 150000 - ((teszttav/100) * 15) - (teszttav * 20);
        Assert.AreEqual(expected, nyereseg);
    }
}
