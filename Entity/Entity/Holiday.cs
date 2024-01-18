using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entity.Entity
{
    [Table("TB_HOLIDAY")]
    public class Holiday
    {
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Legislation { get; set; }

        [Required]
        public string Type { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public List<VariableDate> VariableDates { get; set; }
    }
}




