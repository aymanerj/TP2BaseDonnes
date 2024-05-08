using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Keyless]
    [Table("CouleurDEquipe", Schema = "Equipes")]
    public partial class CouleurDequipe
    {
        [Column("couleurEquipe")]
        [StringLength(25)]
        public string? CouleurEquipe { get; set; }
    }
}
