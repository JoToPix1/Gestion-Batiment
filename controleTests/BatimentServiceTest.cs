using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using controle.Models;
using controle.Service;


namespace controleTests
{
    internal class BatimentServiceTest
    {
        BatimentService persService = new BatimentService();

        [Test]
        public void CreerMessageTest()
        {
            // prepare 
            Batiment p = new Batiment();

            p.Nom = "EPSI"; 
            p.Code = "B001";
            p.Adresse = "11 tour de l'eau";
            p.CodePostal = 38100;
            p.Ville = "Grenoble";

            BatimentService persService = new BatimentService();
            // execute
            var result = persService.CreerMessage(p);

            // verify
            Assert.AreEqual("Le batiment EPSI, B001, situé au 11 tour de l'eau, Grenoble, 38100.", result);
        }

        [TestCase("Le batiment EPSI, B001, situé au 11 tour de l'eau, Grenoble, 38101.",38101)]
        [TestCase("Le batiment EPSI, B001, situé au 11 tour de l'eau, Grenoble, 38104.",38104)]
        public void CreerMessageCodePostalTest(string expectedResult, int codepostal) {
            // prepare 
            Batiment p = new Batiment()
            {
                Nom = "EPSI",
                Code = "B001",
                Adresse = "11 tour de l'eau",
                Ville = "Grenoble",
                CodePostal = codepostal,
            };

            // execute
            var result = persService.CreerMessage(p);

            // verify
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
            public void CreerBatimentTest()
        {

            // prepare
            persService.InteractUsrService = new InteractionUtilisateurServiceMock();

            // do
            Batiment p = persService.CreerBatiment();

            // verify
            Assert.AreEqual("EPSI", p.Nom);
            Assert.AreEqual("B001", p.Code);
            Assert.AreEqual("13 tour de l'eau", p.Adresse);
            Assert.AreEqual("Grenoble", p.Ville);
            Assert.AreEqual(38100, p.CodePostal);
        }


        public class InteractionUtilisateurServiceMock : InteractionUtilisateurService
        {
            public override int DemandeInt(string message)
            {
                return 38100;
            }
            public override string DemandeString(string message)
            {
                if (message == "Veuillez indiquer votre code : ")
                {
                    return "B001";
                }
                else if (message == "Veuillez indiquer le nom du batiment : ")
                {
                    return "EPSI";
                }
                else if (message == "Veuillez indiquer votre adresse: ")
                {
                    return "13 tour de l'eau";
                }
                else if (message == "Veuillez indiquer votre ville : ")
                {
                    return "Grenoble";
                }
                else if (message == "Veuillez indiquer votre code Postal : ")
                {
                    return "38102";
                }
                return string.Empty;
            }

        }
    }
}


