using Tp2_BaseDonnes.Models;

namespace Tp2_BaseDonnes.ViewModels
{
    public class DescriptionViewModel
    {
        public Equipe equipe { get; set; }
        public CouleurDequipe CouleurDequipe { get; set; }
        public List<Match1> Match1 { get; set; }
    }
}
