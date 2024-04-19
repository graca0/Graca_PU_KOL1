using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class HistoriaRequestDTO
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int idGrupy { get; set; }
        public string tryb_akcji { get; set; }
        public DateTime data { get; set; }

        public HistoriaRequestDTO(Historia h)
        {
            Id = h.ID;
            Imie = h.Imie;
            Nazwisko = h.Nazwisko;
            idGrupy = h.idGrupy;
            tryb_akcji = h.tryb_akcji;
            data = h.data;
        }
    }
    public class HistoriaResponseDTO
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int idGrupy { get; set; }
        public string tryb_akcji { get; set; }
        public DateTime data { get; set; }

        public HistoriaResponseDTO() { }
        public HistoriaResponseDTO(Historia h)
        {
            Imie = h.Imie;
            Nazwisko = h.Nazwisko;
            idGrupy = h.idGrupy;
            tryb_akcji = h.tryb_akcji;
            data = h.data;
        }
    }
}
