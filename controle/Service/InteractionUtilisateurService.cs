using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle.Service {
public class InteractionUtilisateurService : IInteractionUtilisateurService

{
    /// <summary>
    /// Affiche un message à l'utilisateur
    /// </summary>
    /// <param name="message">Message à afficher</param>
    public virtual void AfficherMessage(string message)
    {
        Console.WriteLine(message);
    }

    public virtual string LireSaisieUtilisateur()
    {
        return Console.ReadLine() ?? string.Empty;
    }
    public virtual int DemandeInt(string message)
    {
        int result;
        while (true)
        {
            string userInput = DemandeString(message);
            if (int.TryParse(userInput, out result) == false)
            {
                AfficherMessage("Idiot, saisie incorrecte");
            }
            else
            {
                break;
            }
        }
        return result;
    }
        public virtual string AttendrePourQuitter()
        {
            return Console.ReadLine() ?? string.Empty;
        }
        public virtual string DemandeString(string message)
    {
        string result;
        while (true)
        {
            AfficherMessage(message);
            string userInput = LireSaisieUtilisateur();
            if (string.IsNullOrEmpty(userInput))
            {
                AfficherMessage("Idiot, saisie incorrecte");
            }
            else
            {
                result = userInput;
                break;
            }
        }
        return result;
    }
  }
}
