using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("Equipe", Schema = "Equipes")]
    [Index("NomEquipe", Name = "UQ_Equipe_NomEquipe", IsUnique = true)]
    public partial class Equipe
    {
        public Equipe()
        {
            ContratEntraineurs = new HashSet<ContratEntraineur>();
            ContratJoueurs = new HashSet<ContratJoueur>();
            Match1s = new HashSet<Match1>();
        }

        [Key]
        public int EquipeId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? NomEquipe { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Pays { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateFondation { get; set; }
        public byte[]? CouleurMasQue { get; set; }

        [InverseProperty("Equipe")]
        public virtual ICollection<ContratEntraineur> ContratEntraineurs { get; set; }
        [InverseProperty("Equipe")]
        public virtual ICollection<ContratJoueur> ContratJoueurs { get; set; }
        [InverseProperty("Equipe")]
        public virtual ICollection<Match1> Match1s { get; set; }
    }
}
