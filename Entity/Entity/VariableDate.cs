using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    [Table("TB_VARIABLEDATE")]
    public class VariableDate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Feriado")]
        public int FeriadoId { get; set; }

        public int Year { get; set; }

        [Required]
        public string Date { get; set; }

        public Holiday Feriado { get; set; }
    }
}
