using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}
