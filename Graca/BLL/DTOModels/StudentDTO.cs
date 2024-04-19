using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class StudentRequestDTO
    {
        public int Id { get;  }
        public string Imie{ get;  }
        public string Nazwisko{ get;  }
        public int? IdGrupa { get;  }

        public StudentRequestDTO(Student s) 
        {
            Id = s.ID;
            Imie = s.Imie;
            Nazwisko = s.Nazwisko;
            IdGrupa = s.IDGrupy;
        }
    }
    public class StudentResponseDTO
    {

        public string Imie { get; }
        public string Nazwisko { get; }
        public int? IdGrupa { get; }

        public StudentResponseDTO(Student s)
        {
            Imie = s.Imie;
            Nazwisko = s.Nazwisko;
            IdGrupa = s.IDGrupy;
        }
    }
}
