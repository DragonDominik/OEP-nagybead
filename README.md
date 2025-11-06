# Feladat

## 4. Modellezzük egy kamionos cég működését!

A kamionos cég sofőrökkel (név, jogosítvány szám), és kamionokkal (rendszám, tengelyekre vetített terhelhetőség,
fogyasztás) rendelkezik. Tengelyeinek száma 3, ha nyergesvontató; 2, ha fülkésvázas. A cég sofőröket alkalmazhat vagy
bocsájthat el; kamionokat szerezhet be vagy adhat el; fuvart vállalhat el, amelyet egyik kamionjára és sofőrjére bízhat.
Egy fuvarról nyilvántartják a szállítandó teher kezdő és célállomását, azok távolságát, a teher súlyát, a fuvar díját, a
szállítást végző kamiont és a sofőrt. Egy kamion legfeljebb a maximális terhelhetőségével (tengelyek száma ⋅
tengelyterhelés ) azonos súlyú terhet szállíthat. Ugyanarra a kamionra több fuvar is rábízható, de ezeket csak egyesével
tudja teljesíteni: külön jelzi, amikor elindult fuvarért; külön, amikor felvette (rögzíti az indulási időt, hozzáadja a fuvar
távolsághoz a fuvar felvételéhez megtett távolságot); és amikor teljesítette (rögzíti az érkezési időt). A sofőrök a
teljesített fuvarjaik után kapnak bért, amely a fuvarjaikkal megtett távolságnak és annak az együtthatónak a szorzata,
amelyik a kamion típusától (nyerges, fülkés), illetve a sofőr besorolásától(kezdő, gyakorlott, törzstag) függ.

a. Melyik a cég azon legkisebb terhelhetőségű kamionja, amelyik képes egy adott terhet fuvarozni?

b. Van-e olyan kamion, amelyikhez nincs fuvar rendelve?

c. Mekkora a nyeresége a cégnek egy adott időszakban teljesített fuvarjai alapján? (fuvar nyeresége = szállítási díj –
távolság ⋅ fogyasztás – bér)?

d. Mennyi bér jár egy sofőrnek egy adott időszakban teljesített fuvarjai alapján?

Készítsen használati eset diagramot a cég, illetve egy sofőr szempontjából! Ebben jelenjenek meg használati esetként
a később bevezetett fontosabb metódusok. Adjon meg a fenti feladathoz egy olyan objektum diagramot, amely mutat
egy céget, annak két sofőrjét, három kamionját, és öt fuvarját, valamint az ezek közötti kapcsolatokat. Egészítse ezt ki
kommunikációs diagrammá!

Készítse el egy kamion objektum állapotgépét! Különböztesse meg a „szabad”, „fuvarért megy”, „fuvart szállít”
állapotokat. Tervezze meg az állapot-átmeneteket megvalósító tevékenységeket (egy újabb fuvart vállal, elindul egy
fuvarért, felveszi az árut, teljesíti a fuvart), amelyeket a kamion osztály metódusaiként kell definiálni.

Rajzolja fel a feladat osztály diagramját! Felteheti, hogy a rejtett adattagokhoz mindig tartozik egy publikus getter: ha
mégsem, akkor azt a „secret” megjegyzéssel jelölje. Egészítse ki az osztálydiagramot az objektum-kapcsolatokat
létrehozó metódusokkal, valamint a feladat kérdéseit megválaszoló metódusokkal. A metódusok leírása legyen minél
tömörebb (például ciklusok helyett a megfelelő algoritmus minta specifikációs jelölését használja). Használjon tervezési
mintákat, és mutasson rá, hogy hol melyiket alkalmazta. (Egy sofőr bérét a fuvarozással megtett távolságnak, valamint
sofőr besorolásától és a szállítást végző kamion fajtájától függő tényezőnek szorzatából számolja a látogató tervezési
minta alapján.)

Implementálja a modellt! Szerkesszen olyan szöveges állományt, amelyből fel lehet populálni egy cég telephelyeit,
kamionjait, sofőrjeit, fuvarjait, a fuvarozás ütemezését. Készítsen teszteseteket, néhánynak rajzolja fel a szekvencia
diagramját, és hozzon létre ezek kipróbálására automatikusantesztkörnyezetet!

# Megoldás tartalma

- dokumentáció.pdf: a feladathoz tartozó UML diagramok és azok részletes leírása
- EC9VQV_BEAD: a rendszer C# megvalósítása
- TEST_BEAD: a C# megoldáshoz tartozó automatikus tesztek
