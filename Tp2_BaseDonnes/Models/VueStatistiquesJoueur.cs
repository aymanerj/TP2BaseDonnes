using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tp2_BaseDonnes.Models
{
    [Keyless]
    public partial class VueStatistiquesJoueur
    {
        public int JoueurId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Nom { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Prenom { get; set; }
        public int? NombreButs { get; set; }
        public int? NombreMatchsJoues { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? NomEquipe { get; set; }
    }
}
