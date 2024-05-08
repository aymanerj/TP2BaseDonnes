namespace Tp2_BaseDonnes.Models
{
    public class DetailedBut
    {
        public int ButId { get; set; }
        public DateTime DateBut { get; set; }
        public int MinuteBut { get; set; }
        public string DescriptionBut { get; set; }
        public int JoueurId { get; set; }
        public string JoueurNom { get; set; }
        public string JoueurPrenom { get; set; }
        public int EquipeId { get; set; }
        public string NomEquipe { get; set; }
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public DateTime MatchHeure { get; set; }
        public int MatchDuree { get; set; }
    }
}
