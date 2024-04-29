using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("Joueur", Schema = "Equipes")]
    [Index("Nom", "Prenom", "DateNaissance", Name = "UQ_Joueur_Nom_Prenom", IsUnique = true)]
    public partial class Joueur
    {
        public Joueur()
        {
            Buts = new HashSet<But>();
            ContratJoueurs = new HashSet<ContratJoueur>();
            GardienButs = new HashSet<GardienBut>();
        }

        [Key]
        public int JoueurId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Nom { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Prenom { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateNaissance { get; set; }
        [Column("sexe")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Sexe { get; set; }
        [Column("age")]
        public int? Age { get; set; }

        [InverseProperty("Joueur")]
        public virtual ICollection<But> Buts { get; set; }
        [InverseProperty("Joueur")]
        public virtual ICollection<ContratJoueur> ContratJoueurs { get; set; }
        [InverseProperty("Joueur")]
        public virtual ICollection<GardienBut> GardienButs { get; set; }
    }
}
