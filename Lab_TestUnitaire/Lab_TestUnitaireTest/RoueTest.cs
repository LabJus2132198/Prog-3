using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [TestClass]
    public class RoueTest
    {
        int largeur;
        int pourcentageHauteur;
        int diametreJante;
        int indiceCharge;
        char indiceVitesse;
        int pression;
        string type;
        Roue r;

        [TestInitialize]
        public void Init()
        {
            largeur = 1;
            pourcentageHauteur = 2;
            diametreJante = 3;
            indiceCharge = 0;
            indiceVitesse = 'a';
            pression = 2;
            type = "allo";
            r = new Roue(largeur, pourcentageHauteur, diametreJante, indiceCharge, indiceVitesse, pression, type);
        }

        [TestCleanup]
        public void CleanUp()
        {
            largeur = 0;
            pourcentageHauteur = 0;
            diametreJante = 0;
            indiceCharge = 0;
            indiceVitesse = ' ';
            pression = 0;
            type = null;
            r = null;
        }

        [TestMethod]    
        public void Roue_ValeurCorrecte_RoueMemeValeur()
        {
            Assert.AreEqual<int>(largeur, r.Largeur);
            Assert.AreEqual<int>(pourcentageHauteur, r.PourcentageHauteur);
            Assert.AreEqual<int>(diametreJante, r.DiametreJante);
            Assert.AreEqual<int>(indiceCharge, r.IndiceCharge);
            Assert.AreEqual<char>(indiceVitesse, r.IndiceVitesse);
            Assert.AreEqual<int>(pression, r.Pression); 
            Assert.AreEqual<string>(type, r.Type);
        }

        [TestMethod]
        public void Roue_ValeurCorrecte_RoueCopieValeur()
        {
            Roue s = new Roue(r);

            Assert.AreEqual<int>(r.Largeur, s.Largeur);
            Assert.AreEqual<int>(r.PourcentageHauteur, s.PourcentageHauteur);
            Assert.AreEqual<int>(r.DiametreJante, s.DiametreJante);
            Assert.AreEqual<int>(r.IndiceCharge, s.IndiceCharge);
            Assert.AreEqual<char>(r.IndiceVitesse, s.IndiceVitesse);
            Assert.AreEqual<int>(r.Pression, s.Pression);
            Assert.AreEqual<string>(r.Type, s.Type);
        }

        [TestMethod]
        public void GonflerPneu_ValeurCorrecte_AdditionÉquivautEtAffichage()
        {
            int resultatAddition = r.Pression + 1;
            r.GonflerPneu(1);
            Assert.AreEqual(resultatAddition, r.Pression);  
        }
    }
}
