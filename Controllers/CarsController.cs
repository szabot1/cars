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

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(CarsContext ctx, Guid id, UpdateCarDto car)
        {
            var existingCar = ctx.Cars.FirstOrDefault(car => car.Id == id);
            if (existingCar == null)
            {
                return NotFound();
            }

            ctx.Entry(existingCar).CurrentValues.SetValues(car);
            ctx.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(CarsContext ctx, Guid id)
        {
            var existingCar = ctx.Cars.FirstOrDefault(car => car.Id == id);
            if (existingCar == null)
            {
                return NotFound();
            }

            ctx.Cars.Remove(existingCar);
            ctx.SaveChanges();

            return NoContent();
        }
    }
}