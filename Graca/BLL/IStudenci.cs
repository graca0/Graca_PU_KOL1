using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStudenci
    {
        public void Create(string imie, string nazwisko, int? idgrupa = null);
        public IEnumerable<StudentResponseDTO> GetStudents();
        public StudentResponseDTO GetStudents(int id);
        public void Update(int id, string imie, string nazwisko, int? grupa);
        public void Delete(int id);

      
    }
}
