using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Keyless]
    [Table("DescriptionBut", Schema = "Matchs")]
    public partial class DescriptionBut
    {
        [Column("DescriptionBut")]
        [StringLength(25)]
        public string? DescriptionBut1 { get; set; }
    }
}
