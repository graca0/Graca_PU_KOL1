using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Historia
    {
        //– ID, imię, nazwisko, idGrupy, typ_akcji (usuwanie lub edycja), data
        [Key]
        public int ID { get; set; }
        [Required]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public int idGrupy{ get; set; }
        [Required]
        public string tryb_akcji { get; set; }
        [Required]
        public DateTime data { get; set; }

    }
}
