using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controle.Models;

namespace controle.Service
{
    public class BatimentService
    {
        public InteractionUtilisateurService InteractUsrService { get; set; }
            = new InteractionUtilisateurService();

        public List<Batiment> lesBatiment = new List<Batiment>();
        public Batiment CreerBatiment()
        {
            Batiment p = new Batiment();

            p.Nom = InteractUsrService.DemandeString("Veuillez indiquer le nom du batiment : ");
            p.Code = InteractUsrService.DemandeString("Veuillez indiquer votre code : ");
            p.Adresse = InteractUsrService.DemandeString("Veuillez indiquer votre adresse: ");
            p.Ville = InteractUsrService.DemandeString("Veuillez indiquer votre ville : ");
            p.CodePostal = InteractUsrService.DemandeInt("Veuillez indiquer votre code Postal : ");
            
            lesBatiment.Add(p);
            return p;
        }

        public void AfficherBatiments(Batiment p)
     
            {
                InteractUsrService.AfficherMessage($"Nom du batiment : {p.Nom}");
                InteractUsrService.AfficherMessage($"Code du batiment : {p.Code}");
                InteractUsrService.AfficherMessage($"Adresse du batiment : {p.Adresse}");
                InteractUsrService.AfficherMessage($"Ville du batiment : {p.Ville}");
                InteractUsrService.AfficherMessage($"Code postale du batiment : {p.CodePostal}");
                InteractUsrService.AfficherMessage(" ");
            }

        public void AfficherUnBatiment()
        {
            InteractUsrService.AfficherMessage("Liste des bâtiments existants : ");
            foreach (var b in lesBatiment)
            {
                InteractUsrService.AfficherMessage($"- {b.Nom}");
            }
            string nomBatiment = InteractUsrService.DemandeString("Entrez le nom du bâtiment existant : ");
            Batiment p = lesBatiment.FirstOrDefault(b => b.Nom == nomBatiment);
            if (p != null)
            {
                InteractUsrService.AfficherMessage(" ");
                InteractUsrService.AfficherMessage("Détails du bâtiment sélectionné :");
                InteractUsrService.AfficherMessage($"Nom : {p.Nom}");
                InteractUsrService.AfficherMessage($"Code : {p.Code}");
                InteractUsrService.AfficherMessage($"Adresse : {p.Adresse}");
                InteractUsrService.AfficherMessage($"Ville : {p.Ville}");
                InteractUsrService.AfficherMessage($"Code Postal : {p.CodePostal}");
            }
            else
            {
                InteractUsrService.AfficherMessage("Le bâtiment sélectionné n'existe pas.");
                InteractUsrService.AfficherMessage(" ");
            }
        }

        public void AfficherLesBatiments()
        {
            foreach (Batiment p in lesBatiment)
            {
                AfficherBatiments(p);
            }
        }
        public string RechercheBatiment()
        {
            InteractUsrService.AfficherMessage("Liste des bâtiments existants : ");
            foreach (var b in lesBatiment)
            {
                InteractUsrService.AfficherMessage($"- {b.Nom}");
            }

            string nomBatiment;
            do
            {
                nomBatiment = InteractUsrService.DemandeString("Entrez le nom du bâtiment existant : ");
            } while (!IsNomBatimentValide(nomBatiment));

            return nomBatiment;
        }

        private bool IsNomBatimentValide(string nom)
        {
            foreach (var b in lesBatiment)
            {
                if (b.Nom.Equals(nom))
                {
                    return true;
                }
            }
            return false;
        }
        
        public string CreerMessage(Batiment pers)
        {
            return $"Le batiment {pers.Nom}, {pers.Code}, situé au {pers.Adresse}, {pers.Ville}, {pers.CodePostal}.";
        }
    }
}