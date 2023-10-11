using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieStandApi.Data;
using CookieStandApi.Models;
using CookieStandApi.Models.Interfaces;
using CookieStandApi.Models.DTOs;
using System.Net;

namespace CookieStandApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStand _cookie;

        public CookieStandsController(ICookieStand cookie)
        {
            _cookie = cookie;
        }

        // GET: api/CookieStands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookieStandViewDto>>> GetCookieStands()
        {
            var result= await _cookie.GetAll();
            return result;
        }

        // GET: api/CookieStands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStandViewDto>> GetCookieStand(int id)
        {
          var result =await _cookie.GetById(id);
          return result;
        }

        // PUT: api/CookieStands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookieStand(int id, CookieStandDto cookieStand)
        {
            var result = await _cookie.Update(id,cookieStand);
            return Ok(result);
        }

        // POST: api/CookieStands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CookieStandViewDto>> PostCookieStand(CookieStandDto cookieStand)
        {
            var result = await _cookie.Create(cookieStand);
            return result;
        }

        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookieStand(int id)
        {
            await _cookie.Delete(id);

            return Ok("Removed Successfully");
        }

    }
}
