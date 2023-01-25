using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Ramos.Data;
using SWProvincias_Ramos.Models;

namespace SWProvincias_Ramos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public CiudadController(DBPaisFinalContext context) {
        this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }


        //Get By Autor
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Ciudad>> Get(int id)
        {

            List<Ciudad> ciudad = (from l in context.Ciudades
                                      where l.IdCiudad == id
                                        select l).ToList();

            return ciudad;

        }

        //Post
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from a in context.Ciudades
                             where a.IdCiudad == id
                         select a).SingleOrDefault();
            if (ciudad == null)
            {

                return NotFound();

            }
            context.Ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;

        }
    }
}
