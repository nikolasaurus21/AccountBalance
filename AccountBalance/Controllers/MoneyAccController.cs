﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountBalance.Models;
using AccountBalance.Data;

namespace AccountBalance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoneyAccController : ControllerBase
    {
        private readonly AccountBalanceContext _context;

        public MoneyAccController(AccountBalanceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyAccDTO>>> GetAll()
        {
            return Ok(await _context.MoneyAccounts.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyAccDTO>>> GetSavedAmount(int id)
        {
            var user = await _context.MoneyAccounts.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Saved);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyAccDTO>>> GetBalance(int id)
        {
            var user = await _context.MoneyAccounts.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Balance);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyAccDTO>>> GetExpences(int id)
        {
            var user = await _context.MoneyAccounts.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Expences);
        }

        [HttpPost]
        public async Task<ActionResult<MoneyAccDTO>> CreateNewAcc(MoneyAccDTO accDTO)
        {
            var user = await _context.MoneyAccounts.FirstOrDefaultAsync(x=> x.UserId == accDTO.UserId);
            if (user == null)
            {
            var macc = new MoneyAccount()
            {
                Balance = accDTO.Balance,
                Expences = accDTO.Expences,
                Salary = accDTO.Salary,
                Saved = accDTO.Saved,
                UserId = accDTO.UserId,
            };
                
            _context.MoneyAccounts.Add(macc);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Salary(int id)
        {
            var usersalary = await _context.MoneyAccounts.FirstOrDefaultAsync(x => x.UserId == id);
            if(usersalary == null)
            {
                return NotFound();
            }

            else
            {
               /* var acchistory = new MoneyHistory()
                {
                    Amount = usersalary.Salary,
                    Date = DateTime.UtcNow,
                    Description = "Salary",
                    HistoryType = HistoryType.Salary
                };
                _context.MoneyHistories.Add(acchistory);*/

                usersalary.Balance += usersalary.Salary;
                await _context.SaveChangesAsync();
                return Ok();
            }

        }

        [HttpPost]
        public async Task<ActionResult> Savings(int id, decimal amount)
        {
            var usersaving = await _context.MoneyAccounts.FirstOrDefaultAsync(x => x.UserId == id);
            if (usersaving == null)
            {
                return NotFound();
            }

            else
            {
                
                if (amount < 0 || amount > usersaving.Balance / 2)
                {
                    return BadRequest("Amount must be > 0 and amount cant be greater than half of your balance");
                }


               /* var acchistory = new MoneyHistory()
                {
                    Amount = amount,
                    Date = DateTime.Now,
                    Description = "Saving",
                    HistoryType= HistoryType.Saving
                };
                _context.MoneyHistories.Add(acchistory);*/

                usersaving.Balance -= amount;
                usersaving.Saved += amount;
                
                await _context.SaveChangesAsync();
                
                return Ok();
            }


        }
    }
}