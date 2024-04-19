using BLL;
using BLL.DTOModels;
using DAL;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
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

        //public void Create(string imie, string nazwisko, int? idgrupa = null)
        //{
        //    var student = new Student()
        //    {
        //        Imie = imie,
        //        Nazwisko = nazwisko,
        //        IDGrupy = idgrupa,
        //    };
        //    dbContext.Add(student);
        //    dbContext.SaveChanges();
        //}
        public void Create(string imie, string nazwisko, int? idgrupa = null)
        {
            var connectionString = DbConnection.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@imie", imie);
                    command.Parameters.AddWithValue("@nazwisko", nazwisko);
                    command.Parameters.AddWithValue("@grupaId", idgrupa);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            var student = dbContext.Studenci?.FirstOrDefault(x => x.ID == id);
            if (student != null)
            {
                dbContext.Remove(student);
                dbContext.SaveChanges();
                
            }
            
        }

        //public IEnumerable<HistoriaResponseDTO> GetHistory(int page, int pageSize)
        //{
        //    var historia = dbContext.Historie?.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new HistoriaResponseDTO(x));
        //    return historia;
        //}   
        public IEnumerable<HistoriaResponseDTO> GetHistory(int page, int pageSize)
        {
            var connectionString = DbConnection.ConnectionString;
            var historia = new List<HistoriaResponseDTO>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Historia", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@page", page);
                    command.Parameters.AddWithValue("@pageSize", pageSize);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Id = reader.GetInt32(0);
                            var Imie = reader.GetString(1);
                            var Nazwisko = reader.GetString(2);
                            var grupa = reader.GetInt32(3);
                            var Tryb_akcji = reader.GetString(4);
                            var Data = reader.GetDateTime(5);

                            historia.Add(new HistoriaResponseDTO()
                            {
                                Imie = Imie,
                                Nazwisko = Nazwisko,
                                idGrupy = grupa,
                                tryb_akcji = Tryb_akcji,
                                data = Data
                            });
                        }
                    }
                    return historia;
                }
            }
           
        }

        public IEnumerable<HistoriaResponseDTO> GetHistoryAll()
        {
            var historia = dbContext.Historie?.Select(x=>new  HistoriaResponseDTO(x));
            return historia;
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
