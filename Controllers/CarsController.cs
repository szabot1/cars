using Cars.Data;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CarDto>> GetAll(CarsContext ctx)
        {
            return Ok(ctx.Cars.Select(user => user.ToDto()));
        }

        [HttpGet("{id}")]
        public ActionResult<CarDto> Get(CarsContext ctx, Guid id)
        {
            var car = ctx.Cars.FirstOrDefault(car => car.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car.ToDto());
        }

        [HttpPost]
        public ActionResult Create(CarsContext ctx, CreateCarDto car)
        {
            ctx.Cars.Add(new()
            {
                Name = car.Name,
                Description = car.Description
            });
            ctx.SaveChanges();

            return Ok();
        }
    }
}