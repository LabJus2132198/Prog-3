
namespace ConsoleApp2
{
    [TestClass]
    public class MoteurTest
    {
        int taille;
        int nbCylindres;
        int puissanceChevauxVapeur;
        double consommationParKm;
        Moteur m;

        [TestInitialize]
        public void Init()
        {
            taille = 1;
            nbCylindres = 2;
            puissanceChevauxVapeur = 1;
            consommationParKm = 3;
            m = new Moteur(taille, nbCylindres, puissanceChevauxVapeur, consommationParKm);
        }

        [TestCleanup]
        public void CleanUp()
        {
            taille = 0;
            nbCylindres = 0;
            puissanceChevauxVapeur = 0;
            consommationParKm = 0;
            m = null;
        }

        [TestMethod]
        public void Moteur_valeurCorrecte_MoteurMemeValeur()
        {
            Assert.AreEqual<int>(taille, m.Taille);
            Assert.AreEqual<int>(nbCylindres, m.NbCylindres);
            Assert.AreEqual<int>(puissanceChevauxVapeur, m.PuissanceChevauxVapeur);
            Assert.AreEqual<double>(consommationParKm, m.ConsommationParKm);
        }

        [TestMethod]
        public void DemarrerMoteur_valeurCorrecte_AfficheVroom()
        {
            string affichageAttendu = "Vrooooom !";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.DemarrerMoteur();
                
                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }
        }
    }
}