using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle.Service
{
    internal interface IInteractionUtilisateurService
    {
        void AfficherMessage(string message);
        int DemandeInt(string message);
        string DemandeString(string message);
        string LireSaisieUtilisateur();
    }
}
