using BLL;
using BLL.DTOModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Graca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StucenciController : ControllerBase
    {
        private readonly IStudenci _studenci;
        public StucenciController(IStudenci studenci)
        {
            this._studenci = studenci;
        }
        // GET: api/<StucenciController>
        [HttpGet]
        public IEnumerable<StudentResponseDTO> Get()
        {
            return _studenci.GetStudents();
        }

        // GET api/<StucenciController>/5
        [HttpGet("{id}")]
        public StudentResponseDTO Get(int id)
        {
            return _studenci.GetStudents(id);
        }

        // POST api/<StucenciController>
        [HttpPost]
        public void Post([FromBody] string imie,string nazwisko, int? grupaId = null)
        {
            this._studenci.Create(imie, nazwisko, grupaId); 
        }

        // PUT api/<StucenciController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StucenciController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studenci.Delete(id);
        }
    }
}
