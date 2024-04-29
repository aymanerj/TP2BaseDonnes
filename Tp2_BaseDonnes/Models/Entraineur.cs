using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("Entraineur", Schema = "Equipes")]
    [Index("Nom", "Prenom", "DateNaissance", Name = "UQ_Entraineur_Nom_Prenom", IsUnique = true)]
    public partial class Entraineur
    {
        public Entraineur()
        {
            ContratEntraineurs = new HashSet<ContratEntraineur>();
        }

        [Key]
        public int EntraineurId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Nom { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Prenom { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateNaissance { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string? Specialite { get; set; }
        [Column("age")]
        public int? Age { get; set; }

        [InverseProperty("Entraineur")]
        public virtual ICollection<ContratEntraineur> ContratEntraineurs { get; set; }
    }
}
