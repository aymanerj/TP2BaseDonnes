using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Table("ContratEntraineur", Schema = "Contrats")]
    public partial class ContratEntraineur
    {
        [Key]
        public int ContratentraineurId { get; set; }
        public int? EntraineurId { get; set; }
        public int? EquipeId { get; set; }

        [ForeignKey("EntraineurId")]
        [InverseProperty("ContratEntraineurs")]
        public virtual Entraineur? Entraineur { get; set; }
        [ForeignKey("EquipeId")]
        [InverseProperty("ContratEntraineurs")]
        public virtual Equipe? Equipe { get; set; }
    }
}
