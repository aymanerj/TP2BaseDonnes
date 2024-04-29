using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("But", Schema = "Matchs")]
    public partial class But
    {
        [Key]
        public int ButId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateBut { get; set; }
        public int? MinuteBut { get; set; }
        [Column("descriptionBut")]
        [StringLength(25)]
        [Unicode(false)]
        public string? DescriptionBut { get; set; }
        [Column("JoueurID")]
        public int? JoueurId { get; set; }
        public int? MatchId { get; set; }

        [ForeignKey("JoueurId")]
        [InverseProperty("Buts")]
        public virtual Joueur? Joueur { get; set; }
        [ForeignKey("MatchId")]
        [InverseProperty("Buts")]
        public virtual Match1? Match { get; set; }
    }
}
