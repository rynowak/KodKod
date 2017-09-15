using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace KodKodSample
{
    [Route("pet")]
    public class PetController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pet.Id == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("findByStatus")]
        public ActionResult FindByStatus([FromQuery] Status status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet("findByTags")]
        public ActionResult FindByTags([FromQuery] string[] tags)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id, [FromHeader(Name = "api_key")] string apiKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == 0)
            {
                return NotFound();
            }

            return Ok();
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
