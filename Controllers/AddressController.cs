

using Microsoft.AspNetCore.Mvc;
using AdressBookApi_Nurettin.Models;

namespace AdressBookApi_Nurettin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private static readonly List<Address> addresses = new()
        {
            new Address { Id = 1, Name = "Ines Kas", City = "Brüksel", Email = "ineskas@gmail.com", Phone = "5052333333" },
            new Address { Id = 2, Name = "Nurettin Demirel", City = "Mersin", Email = "nurettindemirel361@gmail.com", Phone = "5052333331" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAll() => Ok(addresses);


        [HttpGet("{id:int}")]
        public ActionResult<Address> GetById(int id)
        {
            var address = addresses.FirstOrDefault(a => a.Id == id);
            return address is null ? NotFound() : Ok(address);
        }

        [HttpPost]
        public ActionResult<Address> Create([FromBody] Address address)
        {
            address.Id = (addresses.Count == 0 ? 1 : addresses.Max(a => a.Id) + 1);
            addresses.Add(address);
            return CreatedAtAction(nameof(GetById), new { id = address.Id }, address);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Address> Update(int id, [FromBody] Address updated)
        {
            var existing = addresses.FirstOrDefault(a => a.Id == id);
            if (existing is null) return NotFound();

            existing.Name = updated.Name;
            existing.City = updated.City;
            existing.Email = updated.Email;
            existing.Phone = updated.Phone;

            return Ok(existing);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existing = addresses.FirstOrDefault(a => a.Id == id);
            if (existing is null) return NotFound();
            addresses.Remove(existing);
            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Address>> Search([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q)) return Ok(addresses);

            var result = addresses.Where(a =>
                (!string.IsNullOrEmpty(a.Name) && a.Name.Contains(q, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(a.City) && a.City.Contains(q, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(a.Email) && a.Email.Contains(q, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(a.Phone) && a.Phone.Contains(q, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            return Ok(result);
        }
    }
}
