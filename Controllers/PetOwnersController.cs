using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetAll()
        {
            // JsonSerializer.Serialize<IEnumerable<PetOwner>>
            IEnumerable<PetOwner> theOwners = _context.PetOwners;

            foreach (PetOwner petOwner in theOwners)
            {
                Console.WriteLine(petOwner.name);
            }
            return _context.PetOwners;
        }

        // GET /api/bakers/:id
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petOwner = _context.PetOwners
                .SingleOrDefault(petOwner => petOwner.id == id);

            // Return a `404 Not Found` if the pet owner doesn't exist
            if (petOwner is null)
            {
                return NotFound();
            }
            return petOwner;
        }

        [HttpPost]
        public PetOwner Post(PetOwner petOwner)
        {
            _context.Add(petOwner);
            _context.SaveChanges();
            return petOwner;
        }
    }

}
