using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("Match1", Schema = "Matchs")]
    public partial class Match1
    {
        public Match1()
        {
            Buts = new HashSet<But>();
        }

        [Key]
        public int MatchId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Heure { get; set; }
        public int? Duree { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Gagnant { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Perdant { get; set; }
        public int? EquipeId { get; set; }

        [ForeignKey("EquipeId")]
        [InverseProperty("Match1s")]
        public virtual Equipe? Equipe { get; set; }
        [InverseProperty("Match")]
        public virtual ICollection<But> Buts { get; set; }
    }
}
