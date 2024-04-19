using BLL;
using BLL.DTOModels;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class StudenciInterface : IStudenci
    {
        private readonly ContextBazyDanych dbContext;
        public StudenciInterface(ContextBazyDanych dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string imie, string nazwisko, int? idgrupa = null)
        {
            int id;
            if (dbContext.Studenci == null || dbContext.Studenci.Count()==0)
                 id = 1;
            else
                id = dbContext.Studenci.Max(x => x.ID) + 1;

            var student = new Student()
            {
                ID = id,
                Imie = imie,
                Nazwisko = nazwisko,
                IDGrupy = idgrupa,
            };
            dbContext.Add(student);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Remove(dbContext.Studenci.Where(x => x.ID == id));
        }

        public IEnumerable<StudentResponseDTO> GetStudents()
        {
            var students = dbContext.Studenci?.Select(x => new StudentResponseDTO(x));
            return students;
        }

        public StudentResponseDTO GetStudents(int id)
        {
            var student = dbContext.Studenci?.FirstOrDefault(x => x.ID == id);
            return new StudentResponseDTO(student) ;
        }

        public void Update(int id, string imie, string nazwisko, int? grupa)
        {
            var student = dbContext.Studenci?.FirstOrDefault(x=>x.ID== id);
            if (student == null)
                return;

            student.Imie = imie;
            student.Nazwisko = nazwisko;
            student.IDGrupy = grupa;

            dbContext.Update(student);
            dbContext.SaveChanges();
        }
    }
}
