using APItest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Linq;

namespace APItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        // In-memory list for testing purposes
        private static List<Testers> People = new List<Testers>
            {
                new Testers
                {
                    Id = 1,
                    FirstName = "Berk",
                    LastName = "Hosgoren",
                    Place = "İzmir"
                }
            };

        // Returns all people in the list
        [HttpGet("GetPeople")]

        public async Task<ActionResult<List<Testers>>> GetAllPeople()
        {
            
            return Ok(People);
        }

        // Adds a new person to the list
        [HttpPost("AddAPerson")]

        public async Task<ActionResult<List<Testers>>> AddNewPerson(Testers Person)
        {
            Person.Id = People.Any() ? People.Max(x => x.Id) + 1 : 1;
            People.Add(Person);
            return Ok(People);
        }

        // Deletes a person by their ID
        [HttpDelete("DeleteAPerson")]

        public async Task<ActionResult<List<Testers>>> DeleteAPerson(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);

            if(person == null)
            {
                return NotFound($" No person found with Id {id}. ");
            }

            People.Remove(person);

            Console.WriteLine($" Person with Id {id} has been deleted. ");

            return Ok(new
            {
                Message = $" Person with Id {id} has been successfully deleted. ",
                UpdatedPeople = People
            });
        }

        // Updates an existing person's info
        [HttpPut("InfoUpdate")]

        public async Task<ActionResult<List<Testers>>> UpdatePerson(int id, Testers updatedPerson)
        {
            var person = People.FirstOrDefault(p => p.Id == id);

            if(person == null)
            {
                return NotFound($" No person found with Id {id}. ");
            }

            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;
            person.Place = updatedPerson.Place;

            return Ok(person);
        }

        // Returns the list sorted by ID ascending or descending
        [HttpGet("Sort")]
        
        public async Task<ActionResult<List<Testers>>> SortedPeople(string order = "desc")
        {
            
                List<Testers> sortedPeople;
         

                if (order.ToLower() == "Asc")
                {
                    sortedPeople = People.OrderBy(p => p.Id).ToList();
                }
                else
                {
                    sortedPeople = People.OrderByDescending(p => p.Id).ToList();
                }

               
           
            return Ok(sortedPeople);


        }

        // Uploads a file to the server
        [HttpPost("FileUpload")]

        public async Task<ActionResult<List<Testers>>> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(" No file was uploaded. ");
            }

            var filePath = Path.Combine(" Uploads ", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(" File uploaded successfully. ");
        }

        // Finds a person by ID
        [HttpGet("FindAPerson")]

        public async Task<ActionResult<List<Testers>>> GetPersonViaId(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);

            if(person == null)
            {
                return NotFound($" No person found with Id {id}. ");
            }

            return Ok(person);
        }

        // Finds people from a specific location
        [HttpGet("FindViaLocation")]

        public async Task<ActionResult<List<Testers>>> GetPersonViaPlace(string place)
        {
            var filteredPeople = People.Where(p => p.Place.Equals(place, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(filteredPeople);
        }
            
    }
}
