using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("ContratJoueur", Schema = "Contrats")]
    public partial class ContratJoueur
    {
        [Key]
        public int ContratJoueurId { get; set; }
        [Column("JoueurID")]
        public int? JoueurId { get; set; }
        public int? EquipeId { get; set; }

        [ForeignKey("EquipeId")]
        [InverseProperty("ContratJoueurs")]
        public virtual Equipe? Equipe { get; set; }
        [ForeignKey("JoueurId")]
        [InverseProperty("ContratJoueurs")]
        public virtual Joueur? Joueur { get; set; }
    }
}
