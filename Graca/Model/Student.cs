using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int? IDGrupy {  get; set; }
    }
}
