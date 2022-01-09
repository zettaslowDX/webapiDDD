using CapgeminiDDD.Common.Model;
using CapgeminiDDD.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CapgeminiDDD.Web.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<Student> Get(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        [HttpPost]
        public async Task<Student> Set(Student student)
        {
            return await _studentRepository.InsertStudentAsync(student);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<Student> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
