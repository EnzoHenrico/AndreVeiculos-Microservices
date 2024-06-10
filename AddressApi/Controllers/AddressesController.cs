using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressApi.Data;
using DatabaseApi.Data;
using DatabaseApi.Repositories;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace AddressApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly DatabaseApiContext _context;
        private IStrategy _strategy;

        public AddressesController(DatabaseApiContext context)
        {
            _context = context;
        }

        private static HttpClient viacepClient = new()
        {
            BaseAddress = new Uri("https://viacep.com.br/ws/")
        };

        private void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // GET: api/Addresses/dapper
        [HttpGet("{tech}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress(string tech)
        {
            List<Address> result;
            switch (tech)
            {
                case "dotnet":
                    SetStrategy(new DotNetStrategy());
                    result = _strategy.SelectAll<Address>(Address.Select);
                    break;
                case "dapper":
                    SetStrategy(new DapperStrategy());
                    result = _strategy.SelectAll<Address>(Address.Select);
                    break;
                case "ef":
                    result = await _context.Address.ToListAsync();
                    break;
                default:
                    return NotFound();
            }

            return result;
        }

        // GET: api/Addresses/ef/5
        [HttpGet("{tech}/{id}")]
        public async Task<ActionResult<Address>> GetAddress(string tech, int id)
        {
            Address? address;
            var parameter = new Tuple<string, object>("Id", id);
            switch (tech)
            {
                case "dotnet":
                    SetStrategy(new DotNetStrategy());
                    address = _strategy.SelectOne<Address>(Address.SelectById, parameter);
                    break;
                case "dapper":
                    SetStrategy(new DapperStrategy());
                    address = _strategy.SelectOne<Address>(Address.SelectById, parameter);
                    break;
                case "ef":
                    address = await _context.Address.FindAsync(id);
                    break;
                default:
                    return NotFound();
            }
            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/dotnet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{tech}/{id}")]
        public async Task<IActionResult> PutAddress(string tech, int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            switch (tech)
            {
                case "dotnet":
                    SetStrategy(new DotNetStrategy());
                    _strategy.UpdateOne<Address>(Address.UpdateById, address);
                    break;
                case "dapper":
                    SetStrategy(new DapperStrategy());
                    _strategy.UpdateOne<Address>(Address.UpdateById, address);
                    break;
                case "ef":
                    _context.Entry(address).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AddressExists(id)) return NotFound();
                        throw;
                    }

                    break;
                default:
                    return NotFound();
            }
            return NoContent();
        }

        // POST: api/Addresses/dapper
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{tech}")]
        public async Task<ActionResult<Address>> PostAddress(string tech, AddressDTO addressDto)
        {
            var address = new Address();
            try
            {
                var viacepResponse = await viacepClient.GetAsync($"{addressDto.Zip}/json");
                var addressData =
                    JsonConvert.DeserializeObject<ViaCepJsonResponse>(await viacepResponse.Content.ReadAsStringAsync());

                var addressType = addressData.Logradouro.Split(" ");
                var addressName = addressData.Logradouro.Substring(addressType[0].Length + 1);

                address.AddressName = addressName;
                address.Zip = addressDto.Zip;
                address.Neighborhood = addressData.Bairro;
                address.AddressType = addressType[0];
                address.Complement = addressDto.Complement;
                address.Number = addressDto.Number;
                address.Fu = addressData.Uf;
                address.City = addressData.Localidade;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                throw;
            }

            switch (tech)
            {
                case "dotnet":
                    SetStrategy(new DotNetStrategy());
                    _strategy.InsertOne<Address>(Address.InsertOne, address);
                    break;
                case "dapper":
                    SetStrategy(new DapperStrategy());
                    _strategy.InsertOne<Address>(Address.InsertOne, address);
                    break;
                case "ef":
                    _context.Address.Add(address);
                    break;
                default:
                    return NotFound();
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAddress", new { tech, id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{tech}/{id}")]
        public async Task<IActionResult> DeleteAddress(string tech, int id)
        {
            var parameter = new Tuple<string, object>("Id", id);
            var address = await _context.Address.FindAsync(id);

            if (address == null) return NotFound();

            switch (tech)
            {
                case "dotnet":
                    SetStrategy(new DotNetStrategy());
                    _strategy.DeleteOne(Address.DeleteById, parameter);
                    break;
                case "dapper":
                    SetStrategy(new DapperStrategy());
                    _strategy.DeleteOne(Address.DeleteById, parameter);
                    break;
                case "ef":
                    _context.Address.Remove(address);
                    await _context.SaveChangesAsync();
                    break;
                default:
                    return NotFound();
            }
            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
