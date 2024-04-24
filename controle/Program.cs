
using System;
using System.Collections.Generic;
using controle.Service;
using controle.Models;


// récupération des données utilisateurs
InteractionUtilisateurService interUser = new InteractionUtilisateurService();
BatimentService persService = new BatimentService();
SalleService salleService = new SalleService();

persService.InteractUsrService = interUser;
while (true)
{
    int entreeMenu = interUser.DemandeInt(@"Que voulez vous faire

    1. Créer un Batiment
    2. Afficher tous les Batiments
    3. Afficher un Batiment

    4. Créer une Salle
    5. Afficher les Salles
    6. Afficher une Salle

    7.Compter toutes les places

    10. Quitter");

    if (entreeMenu == 1)
    {
        persService.CreerBatiment();
    }
    else if (entreeMenu == 2)
    {
        persService.AfficherLesBatiments();
    }
    else if (entreeMenu == 3)
    {
        persService.AfficherUnBatiment();
    }
    else if (entreeMenu == 4)
    {
        salleService.CreerSalle();
    }
    else if (entreeMenu == 5)
    {
        salleService.AfficherSalles();
    }
    else if (entreeMenu == 6)
    {
        salleService.AfficherSalle();
    }
    else if (entreeMenu == 7)
    {
        salleService.TotalDePlacesGlobal();
    }
    
    else if (entreeMenu == 10)
    {
        break;
    }
    else
    {
        interUser.AfficherMessage("entrée invalide");
    }

}

  