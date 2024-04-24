using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle.Models {
public class Salle
{
    public string CodeSalle { get; set; }
    public int NbPlaces { get; set; }
    public string Nom { get; set; }
    public Batiment Batiment { get; set; }

    }
}