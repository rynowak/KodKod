using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace KodKodSample.Controllers
{
    [Route("pets")]
    public class PetsController : Controller
    {
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return new Pet[] { };
        }

        [HttpGet("{id}")]
        public Result<Pet> Get(int id)
        {
            return new Pet();
        }

        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
        }
    }

    public class Pet
    {
    }
}
