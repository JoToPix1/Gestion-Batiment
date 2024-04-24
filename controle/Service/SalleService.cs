using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controle.Models;

namespace controle.Service
{
    public class SalleService
    {
        public InteractionUtilisateurService InteractService { get; set; }
            = new InteractionUtilisateurService();
        public BatimentService BatimentService = new BatimentService();

        private List<Salle> listeSalles;
        public SalleService()
        {
            listeSalles = new List<Salle>();
        }

        public Salle CreerSalle()
        {
            Salle s = new Salle();

            s.Nom = InteractService.DemandeString("Entrez le nom de la salle : ");
            s.CodeSalle = InteractService.DemandeString("Veuillez entrez le code de la salle : ");
            s.NbPlaces = InteractService.DemandeInt("Entrez le nombre de places de la salle : ");
            InteractService.AfficherMessage(" ");
            listeSalles.Add(s);
            return s;
        }

        public void AfficherSalles()
        {
            foreach (Salle s in listeSalles)
            {
                InteractService.AfficherMessage($"Nom de la salle : {s.Nom}");
                InteractService.AfficherMessage($"Code de la salle : {s.CodeSalle}");
                InteractService.AfficherMessage($"Nombre de places : {s.NbPlaces}");
                InteractService.AfficherMessage(" ");
            }
        }

        public void AfficherSalle()
        {
            InteractService.AfficherMessage("Liste des Salles existants : ");
            foreach (var e in listeSalles)
            {
                InteractService.AfficherMessage($"- {e.Nom}");
            }
            string nomSalle = InteractService.DemandeString("Entrez le nom de la salle existant : ");
            Salle s = listeSalles.FirstOrDefault(s => s.Nom == nomSalle);
            if (s != null)
            {
                InteractService.AfficherMessage(" ");
                InteractService.AfficherMessage("Détails du bâtiment sélectionné :");
                InteractService.AfficherMessage($"Nom de la salle : {s.Nom}");
                InteractService.AfficherMessage($"Code de salle : {s.CodeSalle}");
                InteractService.AfficherMessage($"Nombre de places : {s.NbPlaces}");
                InteractService.AfficherMessage(" ");
            }
            else
            {
                InteractService.AfficherMessage("La Salle sélectionné n'existe pas.");
                InteractService.AfficherMessage(" ");
            }
        }

        public string RechercheSalle()
        {
            InteractService.AfficherMessage("Liste des salles existants : ");
            foreach (var s in listeSalles)
            {
                InteractService.AfficherMessage($"- {s.Nom}");
            }
            string nomSalle;
            do
            {
                nomSalle = InteractService.DemandeString("Entrez le nom de la salle existant : ");
            } while (!IsNomSalleValide(nomSalle));

            return nomSalle;
        }

        private bool IsNomSalleValide(string nom)
        {
            foreach (var e in listeSalles)
            {
                if (e.Nom.Equals(nom))
                {
                    return true;
                }
            }
            return false;
        }

        
        public void TotalDePlacesGlobal()
        {
            int totalPlaces = 0;
            foreach (var s in listeSalles)
            {
                totalPlaces += s.NbPlaces;
            }
            InteractService.AfficherMessage($"Le nombre de place total est de {totalPlaces}");
            InteractService.AfficherMessage(" ");
        }
    }
}
