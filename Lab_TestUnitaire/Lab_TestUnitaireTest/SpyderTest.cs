using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [TestClass]
    public class SpyderTest
    {
        Moteur moteur;
        int tailleReservoir;
        double distanceParcourue;
        int dureeVieKm;
        int autonomieKm;
        string couleur;
        string marque;
        string modele;
        Spyder spyder;
        Roue roue;

        [TestInitialize]
        public void Init()
        {
            moteur = new Moteur(0, 1, 2, 3);
            roue = new Roue(1, 2, 3, 1, 'a', 2, "b");
            tailleReservoir = 1;
            distanceParcourue = 0;
            dureeVieKm = 3;
            autonomieKm = 1;
            couleur = "c";
            marque = "d";
            modele = "e";
            spyder = new Spyder(dureeVieKm, tailleReservoir, moteur, roue, couleur, marque, modele);
        }

        [TestMethod]
        public void Spyder_valeurCorrect_StyleSpyder()
        {
            string style = "Spyder";
            Assert.AreEqual<string>(style, spyder.Style);
        }

        [TestMethod]
        public void TournerSerrer_RegardeAffichage_AfficheTourantSpyder()
        {
            string affichageAttendu = "Pour faire le tournant serré, vous avez simplement tourné la direction de la Spyder.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                spyder.TournerSerrer();

                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }
        }
    }
}
