using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Data.Models;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            //NOTE: Merren te gjithe studentet nga databaza
            var allStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Student 1",
                    LastName = "Student 1",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    GraduationYear = 2023,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = null,
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Student 2",
                    LastName = "Student 2",
                    DateOfBirth = DateTime.Now.AddYears(-21),
                    GraduationYear = 2023,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = null,
                }
            };
            return Ok(allStudents);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //NOTE: Merret vetem nje student nga databaza me id
            var student = new Student()
            {
                Id = 1,
                FirstName = "Alijandro",
                LastName = "Firanj",
                GraduationYear = 2023,
                IsActive = true,
                DateOfBirth = DateTime.Now.AddYears(-20),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentVM schoolVM)
        {
            //Krijohet objekti student
            var school = new School()
            {
                //Id = Gjenerohet nga database
                FirstName = studentVM.FirstName,
                LastName=studentVM.LastName,
                GraduationYear = studentvm.GraduationYear,
                IsActive = studentVM.IsActive,
                DateOfBirth = studentVM.DateOfBirth,

            };

            //Objekti Student i krijuar shtohet ne databaze me Entity Framework
            return Created("", student);
        }
        

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody]StudentVM StudentVM, int id)
        {
            //Merret objekti Student nga database duket perdorur Id si parameter
            var student = new Student()
            {
                FirstName = "Alijandro",
                LastName = "Firanj",
                GraduationYear = "2023",
                IsActive = true,
                DateOfBirth = DateTime.Now.AddYears(-20),
            };


            //Modifikohet objekti Student i marre nga databaza duket perdorur te dhenat nga FromBody
            student.FirstName = student.FirstName;
            student.LastName = student.LastName;
            student.GraduationYear = student.GraduationYear;
            student.DateOfBirth = student.DateTime;

            //Perditesohet objekti student ne database me Entity Framework

            return Ok($"School with id = {id} was updated");
        }



        
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            //NOTE: Kalohet Id si parameter dhe fshihet Student nga databaza

            return Ok($"Student with id {id} deleted");
        }



    }

}
