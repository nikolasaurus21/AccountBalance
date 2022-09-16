﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccountBalance.Models;
using AccountBalance.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountBalance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly AccountBalanceContext _context;

        public HistoryController(AccountBalanceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyHistoryDTO>>> GetAll()
        {
            return Ok(await _context.MoneyHistories.ToListAsync());
        }

        
        
    }
}