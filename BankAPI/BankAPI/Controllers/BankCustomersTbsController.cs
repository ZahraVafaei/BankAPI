using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Data;
using AutoMapper;
using BankAPI.Models.BankCustomers;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCustomersTbsController : ControllerBase
    {
        private readonly BankCustomersDbContext _context;
        private readonly IMapper mapper;

        public BankCustomersTbsController(BankCustomersDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/BankCustomersTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankCustomersTb>>> GetBankCustomersTbs()
        {
          if (_context.BankCustomersTbs == null)
          {
              return NotFound();
          }
            return await _context.BankCustomersTbs.ToListAsync();
        }

        // GET: api/BankCustomersTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankCustomersTb>> GetBankCustomersTb(int id)
        {
          if (_context.BankCustomersTbs == null)
          {
              return NotFound();
          }
            var bankCustomersTb = await _context.BankCustomersTbs.FindAsync(id);

            if (bankCustomersTb == null)
            {
                return NotFound();
            }

            return bankCustomersTb;
        }

        // PUT: api/BankCustomersTbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankCustomersTb(int id, BankCustomersTb bankCustomersTb)
        {
            if (id != bankCustomersTb.Id)
            {
                return BadRequest();
            }

            _context.Entry(bankCustomersTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankCustomersTbExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BankCustomersTbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankCustomerDto>> PostBankCustomersTb(BankCustomerDto customerDto)
        {
           var bankCustomersTb = mapper.Map<BankCustomersTb>(customerDto);

          if (_context.BankCustomersTbs == null)
          {
              return Problem("Entity set 'BankCustomersDbContext.BankCustomersTbs'  is null.");
          }
            _context.BankCustomersTbs.Add(bankCustomersTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BankCustomersTbExists(bankCustomersTb.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBankCustomersTb", new { id = bankCustomersTb.Id }, bankCustomersTb);
        }

        // DELETE: api/BankCustomersTbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankCustomersTb(int id)
        {
            if (_context.BankCustomersTbs == null)
            {
                return NotFound();
            }
            var bankCustomersTb = await _context.BankCustomersTbs.FindAsync(id);
            if (bankCustomersTb == null)
            {
                return NotFound();
            }

            _context.BankCustomersTbs.Remove(bankCustomersTb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankCustomersTbExists(int id)
        {
            return (_context.BankCustomersTbs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
