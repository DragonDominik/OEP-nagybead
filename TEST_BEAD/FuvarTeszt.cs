using EC9VQV_BEAD;

namespace TEST_BEAD;

[TestClass]
public class FuvarTeszt
{
    private Fuvar fuvar = null!;
    private Kamion kamion = null!;
    private Sofor sofor = null!;

    [TestInitialize]
    public void Initialize()
    {
        fuvar = new Fuvar("Budapest", "Debrecen", 200, 1000, 150000);
        kamion = new Fulkes("ABC-123", "Budapest", 2000, 20);
        sofor = new Kezdo("Teszt Sofőr", "K123");
    }

    [TestMethod]
    public void KonstruktorTeszt()
    {
        Assert.AreEqual("Budapest", fuvar.kezdo);
        Assert.AreEqual("Debrecen", fuvar.cel);
        Assert.AreEqual(200, fuvar.tav);
        Assert.AreEqual(1000, fuvar.teher);
        Assert.AreEqual(150000, fuvar.dij);
        Assert.IsNull(fuvar.jarmu);
        Assert.IsNull(fuvar.vezeto);
    }

    [TestMethod]
    public void SoforValasztTeszt()
    {
        fuvar.SoforValaszt(sofor);
        Assert.AreEqual(sofor, fuvar.vezeto);
        Assert.IsTrue(sofor.fuvarok.Contains(fuvar));
    }

    [TestMethod]
    public void JarmuValasztTeszt()
    {
        fuvar.JarmuValaszt(kamion);
        Assert.AreEqual(kamion, fuvar.jarmu);
        Assert.IsTrue(kamion.fuvarok.Contains(fuvar));
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void RogzitIndulasHibaTeszt()
    {
        fuvar.RogzitIndulas(); //nincs jármű ezért hiba
    }

    [TestMethod]
    public void RogzitIndulasTeszt()
    {
        fuvar.JarmuValaszt(kamion);
        fuvar.RogzitIndulas();
        Assert.IsNotNull(fuvar.kezdoido);
        Assert.IsTrue(kamion.vanRakomany);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void RogzitErkezesHibaTeszt()
    {
        fuvar.JarmuValaszt(kamion); //nem volt elindulás ezért hiba
        fuvar.RogzitErkezes();
    }

    [TestMethod]
    public void RogzitErkezesTeszt()
    {
        fuvar.JarmuValaszt(kamion);
        fuvar.SoforValaszt(sofor);
        fuvar.RogzitIndulas();
        sofor.Vezet(kamion, "Debrecen");
        fuvar.RogzitErkezes();

        Assert.IsNotNull(fuvar.celido);
        Assert.AreEqual(Allapot.SZABAD, kamion.allapot);
        Assert.IsNull(sofor.jarmu);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void soforBerHibaTeszt()
    {
        int ber = fuvar.soforBer(); //nem volt érkezés
    }

    [TestMethod]
    public void soforBerTeszt()
    {
        fuvar.JarmuValaszt(kamion);
        fuvar.SoforValaszt(sofor);
        fuvar.RogzitIndulas();
        sofor.Vezet(kamion, "Debrecen");
        fuvar.RogzitErkezes();
        int ber = fuvar.soforBer();
        Assert.AreEqual(fuvar.tav * 20 , ber);
    }
}
