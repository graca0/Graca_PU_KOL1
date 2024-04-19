using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [ForeignKey(nameof(IDGrupy))]
        public int? IDGrupy {  get; set; }
        public Grupa? Grupa {  get; set; }
    }
}
