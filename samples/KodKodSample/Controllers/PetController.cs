using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace KodKodSample
{
    [Route("pet")]
    public class PetController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return new Pet[] { };
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            return new Pet();
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (ModelState.IsValid)
            {
                return CreatedAtAction("Get", new { id = pet.Id, }, pet);
            }

            return BadRequest(ModelState);
        }
    }

    public class Pet
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string[] PhotoUrls { get; set; }

        public Tag[] Tags { get; set; }

        public Status Status { get; set; }
    }

    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public enum Status
    {
        Available,
        Pending,
        Sold,
    }

    public class Tag
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
