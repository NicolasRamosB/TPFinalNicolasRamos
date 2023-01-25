using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Ramos.Models;

namespace SWAdventureWorks_Ramos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        
        private readonly AdventureWorks2019Context context;
        
        public CreditCardController(AdventureWorks2019Context context)
        {

            this.context = context;

        }

        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> Get()
        {
            return context.CreditCard.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CreditCard> GetbyId(int id)
        {
            CreditCard creditCard = (from c in context.CreditCard
                                     where c.CreditCardId == id
                                     select c).SingleOrDefault();
            return creditCard;
        }

        [HttpGet("listado/{type}")]
        public ActionResult<IEnumerable<CreditCard>> GetbyType(string type)
        {
            List <CreditCard> creditCard = (from c in context.CreditCard
                                            where c.CardType == type
                                            select c).ToList();
            return creditCard;
        }

        [HttpPost]
        public ActionResult Post(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.CreditCard.Add(creditCard);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreditCard creditCard)
        {
            if (id != creditCard.CreditCardId)
            {
                return BadRequest();
            }
            context.Entry(creditCard).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<CreditCard> Delete(int id)
        {
            var creditCard = (from a in context.CreditCard
                          where a.CreditCardId == id
                          select a).SingleOrDefault();
            if (creditCard == null)
            {

                return NotFound();

            }
            context.CreditCard.Remove(creditCard);
            context.SaveChanges();
            return creditCard;

        }
    }
}
