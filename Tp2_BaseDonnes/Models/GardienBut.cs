using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("GardienBut", Schema = "Equipes")]
    public partial class GardienBut
    {
        [Key]
        public int GardienButId { get; set; }
        public int? ButEncaisse { get; set; }
        public int? CleanSheet { get; set; }
        public int? JoueurId { get; set; }

        [ForeignKey("JoueurId")]
        [InverseProperty("GardienButs")]
        public virtual Joueur? Joueur { get; set; }
    }
}
