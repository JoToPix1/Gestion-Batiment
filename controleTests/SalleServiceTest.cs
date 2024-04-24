using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controle.Models;
using controle.Service;
using static controleTests.BatimentServiceTest;

namespace controleTests
{
    internal class SalleServiceTest
    {
        SalleService salleService = new SalleService();

        [Test]
        public void CreerSalleTest()
        {
            // prepare

            salleService.InteractService = new InteractionUtilisateurServiceMock2();
            // do
            Salle p = salleService.CreerSalle();

            // verify
            Assert.NotNull(p);
            Assert.AreEqual("SN2", p.Nom);
            Assert.AreEqual("A205", p.CodeSalle);
            Assert.AreEqual(12, p.NbPlaces);
        }
    }
    public class InteractionUtilisateurServiceMock2 : InteractionUtilisateurService
    {
        public override int DemandeInt(string message)
        {
            return 12;
        }
        public override string DemandeString(string message)
        {
            if (message == "Entrez le nom de la salle : ")
            {
                return "SN2";
            }
            else if (message == "Veuillez entrez le code de la salle : ")
            {
                return "A205";
            }
            else if (message == "Entrez le nombre de places de la salle : ")
            {
                return "12";
            }
            return string.Empty;
        }
    }
}

