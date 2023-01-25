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
    public class ProvinciaController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public ProvinciaController(DBPaisFinalContext context) {
        this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }


        //Get By Autor
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Provincia>> Get(int id)
        {

            List<Provincia> provincia = (from l in context.Provincias
                                        where l.IdProvincia == id
                                        select l).ToList();

            return provincia;

        }

        //Post
        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from a in context.Provincias
                         where a.IdProvincia == id
                         select a).SingleOrDefault();
            if (provincia == null)
            {

                return NotFound();

            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return provincia;

        }
    }
}
