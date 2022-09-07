using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [TestClass]
    public class MotoTest
    {
        Moteur moteur;
        string style;
        int tailleReservoir;
        double distanceParcourue; 
        int dureeVieKm;
        int autonomieKm;
        string couleur;
        string marque;
        string modele;
        Moto moto;
        Roue roue;

        [TestInitialize]
        public void Init()
        {
            moteur = new Moteur(0, 1, 2, 1);
            roue = new Roue(1, 2, 3, 1, 'a', 2, "b");        
            style = "q";
            tailleReservoir = 2;
            distanceParcourue = 0;
            dureeVieKm = 3;
            autonomieKm = 2;
            couleur = "c";
            marque = "d";
            modele = "e";
            moto = new Moto(dureeVieKm, style, tailleReservoir, moteur, roue, couleur, marque, modele);
        }

        [TestCleanup] 
        public void CleanUp()
        {
            moteur = null;
            style = null;
            tailleReservoir = 0;
            distanceParcourue = 0;
            dureeVieKm = 0;
            autonomieKm = 0;
            couleur = null;
            marque = null;
            modele = null;
            moto = null;
        }

        [TestMethod]
        public void Moteur_valeurCorrecte_MoteurMemeValeur()
        {
            int autonomie = (int)Math.Floor(tailleReservoir / moteur.ConsommationParKm);
            Assert.AreEqual<int>(moteur.Taille, moto.Moteur.Taille);
            Assert.AreEqual<int>(moteur.NbCylindres, moto.Moteur.NbCylindres);
            Assert.AreEqual<int>(moteur.PuissanceChevauxVapeur, moto.Moteur.PuissanceChevauxVapeur);
            Assert.AreEqual<double>(moteur.ConsommationParKm, moto.Moteur.ConsommationParKm);
            for (int i = 0;i < 2;i++)
            {
                Assert.AreEqual<int>(roue.Largeur, moto.Roues[i].Largeur);
                Assert.AreEqual<int>(roue.PourcentageHauteur, moto.Roues[i].PourcentageHauteur);
                Assert.AreEqual<int>(roue.DiametreJante, moto.Roues[i].DiametreJante);
                Assert.AreEqual<int>(roue.IndiceCharge, moto.Roues[i].IndiceCharge);
                Assert.AreEqual<char>(roue.IndiceVitesse, moto.Roues[i].IndiceVitesse);
                Assert.AreEqual<int>(roue.Pression, moto.Roues[i].Pression);
                Assert.AreEqual<string>(roue.Type, moto.Roues[i].Type);
            }
            Assert.AreEqual<int>(tailleReservoir, moto.TailleReservoir);
            Assert.AreEqual<string>(style, moto.Style);
            Assert.AreEqual<double>(distanceParcourue, moto.DistanceParcourue);
            Assert.AreEqual<int>(autonomie, moto.AutonomieKm);
        }

        [TestMethod]
        public void Demarer_RegardeAffichage_AfficheVroom()
        {
            string affichageAttendu = "Vrooooom !";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moteur.DemarrerMoteur();

                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }
        }

        [TestMethod]
        public void DiminuerPression_diminutierPressionDeUn_PressionsDiminuer()
        {
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual<int>(roue.Pression, moto.Roues[i].Pression);
            }

            moto.DiminuerPression();
            int pressionsDiminuer = roue.Pression - 1;

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual<int>(pressionsDiminuer, moto.Roues[i].Pression);
            }
        }

        [TestMethod]
        public void AjouterPression_DoitAjouter_PressionA35()
        {
            moto.AjouterPression();
            int pressionMax = 35;

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual<int>(pressionMax, moto.Roues[i].Pression);
            }
        }

        [TestMethod]
        public void TournerSerrer_valdieAffichage_DoitAfficherTournantSerrer()
        {
            string affichageAttendu = "Pour faire le tournant serré, vous avez dû incliner la moto.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.TournerSerrer();

                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }
        }

        [TestMethod]
        public void FaireLePlein_valideAffichageSansGonflagePneu_AfficheSansGonflagePneu()
        {
            for (int i = 0; i < 2; i++)
            {
                moto.Roues[i].Pression = 35;
            }

            string affichageAttendu = "Pour faire le tournant serré, vous avez dû incliner la moto." + 
                "\r\nVous avez fait le plein !";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.FaireLePlein();

                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }
        }

        [TestMethod]
        public void FaireLePlein_valideAffichageSansGonflagePneu_AfficheAvecGonflagePneu()
        {
            string affichageAttendu = "Pour faire le tournant serré, vous avez dû incliner la moto." +
                "\r\nVous avez gonflé le pneu." +
                "\r\nVous avez gonflé le pneu." +
                "\r\nVous avez fait le plein !";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.FaireLePlein();

                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }
        }

        [TestMethod]
        public void AjouterUsure_ValideAugmentationUsure_UsureAjouteSansAfficherMotoFini()
        {
            double usureCalcul;
            usureCalcul = 1 + moto.DistanceParcourue;
            moto.AjouterUsure(1);

            Assert.AreEqual<double>(usureCalcul, moto.DistanceParcourue);
        }

        [TestMethod]
        public void AjouterUsure_ValideAugmentationUsure_UsureAjouteAvecAffichageMotoFini()
        {
            double usureCalcul;
            usureCalcul = 300 + moto.DistanceParcourue;
            string affichageAttendu = "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.AjouterUsure(300);

                var resultat = sw.ToString().Trim();
                Assert.AreEqual(affichageAttendu, resultat);
            }

            Assert.AreEqual<double>(usureCalcul, moto.DistanceParcourue);
        }

        [TestMethod]
        public void Rouleur_ValideDistanceParcouruAffichageEtUsure_AfficheEtCalculSansAjouterPressionEtUsure()
        {
            int kmAParcourir = 2;
            double distanceParcourue = moto.DistanceParcourue + kmAParcourir;
            string affichageAttendu;
            affichageAttendu = "Vous avez roulé " + moto.AutonomieKm + " km !"
                //+ "\r\nPour faire le tournant serré, vous avez dû incliner la moto."
                //+ "\r\nVous avez fait le plein !"
                //+ "\r\nVous avez roulé " + kmAParcourir + " km !"
                + "\r\nPour faire le tournant serré, vous avez dû incliner la moto."
                + "\r\nVous avez gonflé le pneu." 
                + "\r\nVous avez gonflé le pneu."
                + "\r\nVous avez fait le plein !"
                + "\r\nLe voyage est fini.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.Rouler(2);

                var resultat = sw.ToString().Trim();
                Assert.AreEqual<string>(affichageAttendu, resultat);
            }
            
            Assert.AreEqual<double>(distanceParcourue, moto.DistanceParcourue);
        }
    }   
}
