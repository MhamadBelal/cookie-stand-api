using CookieStandApi.Data;
using CookieStandApi.Migrations;
using CookieStandApi.Models.DTOs;
using CookieStandApi.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CookieStandApi.Models.services
{
    public class CookieStandService : ICookieStand
    {
        private readonly CookieStandDBContext _cotext;
        public CookieStandService(CookieStandDBContext context)
        {
            _cotext = context;
        }
        public async Task<CookieStandViewDto> Create(CookieStandDto cookieStand)
        {
            var Cookie = new CookieStand
            {
                Location= cookieStand.Location,
                Description= cookieStand.Description,
                MinimumCustomersPerHour= cookieStand.MinimumCustomersPerHour,
                MaximumCustomersPerHour=cookieStand.MaximumCustomersPerHour,
                AverageCookiesPerSale= cookieStand.AverageCookiesPerSale,
                Owner=cookieStand.Owner
            };
            _cotext.CookieStands.Add(Cookie);
            await _cotext.SaveChangesAsync();


            int min =(int)(Cookie.MinimumCustomersPerHour * Cookie.AverageCookiesPerSale);
            int max = (int)(Cookie.MaximumCustomersPerHour * Cookie.AverageCookiesPerSale);

            var random = new Random();

            for (int i = 0; i < 14; i++)
            {
                var salePerHour = new HourlySale()
                {
                    CookieStandId = Cookie.Id,
                    SaleValue = random.Next(min, max),
                    CookieStand=Cookie
                };

                _cotext.hourlySales.Add(salePerHour);
                await _cotext.SaveChangesAsync();
            }
            var hours = await _cotext.hourlySales.Where(x => x.CookieStandId == Cookie.Id).Select(s=>s.SaleValue).ToListAsync();

            var CookieDTO = new CookieStandViewDto
            {
                Id=Cookie.Id,
                Location = Cookie.Location,
                Description = Cookie.Description,
                MinimumCustomersPerHour = Cookie.MinimumCustomersPerHour,
                MaximumCustomersPerHour = Cookie.MaximumCustomersPerHour,
                AverageCookiesPerSale = Cookie.AverageCookiesPerSale,
                Owner = Cookie.Owner,
                hourlySale= hours
            };

            return CookieDTO;
        }

        public async Task Delete(int id)
        {
            var cookieStand = await _cotext.CookieStands.FindAsync(id);
            if(cookieStand!=null)
            {
                _cotext.CookieStands.Remove(cookieStand);
                await _cotext.SaveChangesAsync();
            } 
        }

        public async Task<List<CookieStandViewDto>> GetAll()
        {
            var AllCookieStands = await _cotext.CookieStands.Include(h => h.hourlySale).ToListAsync();

            var Cookies = AllCookieStands.Select(cookie=>new CookieStandViewDto
            {
                Id=cookie.Id,
                Location = cookie.Location,
                Description = cookie.Description,
                MinimumCustomersPerHour = cookie.MinimumCustomersPerHour,
                MaximumCustomersPerHour = cookie.MaximumCustomersPerHour,
                AverageCookiesPerSale = cookie.AverageCookiesPerSale,
                Owner = cookie.Owner,
                hourlySale= cookie.hourlySale?.Where(x => x.CookieStandId == cookie.Id).Select(s => s.SaleValue).ToList()
                }).ToList();

            return Cookies;
        }

        public async Task<CookieStandViewDto> GetById(int id)
        {
            var cookieStandItem = await _cotext.CookieStands.Include(x=>x.hourlySale).FirstOrDefaultAsync(i=>i.Id==id);

            if(cookieStandItem == null)
            {
                return null;
            }

            var cookie = new CookieStandViewDto
            {
                Id= cookieStandItem.Id,
                Location = cookieStandItem.Location,
                Description = cookieStandItem.Description,
                MinimumCustomersPerHour = cookieStandItem.MinimumCustomersPerHour,
                MaximumCustomersPerHour = cookieStandItem.MaximumCustomersPerHour,
                AverageCookiesPerSale = cookieStandItem.AverageCookiesPerSale,
                Owner = cookieStandItem.Owner,
                hourlySale = cookieStandItem.hourlySale?.Where(x => x.CookieStandId == cookieStandItem.Id).Select(s => s.SaleValue).ToList()
            };

            return cookie;
        }

        public async Task<CookieStandViewDto> Update(int id, CookieStandDto updatedCookieStand)
        {
            var cookieStandItem = await _cotext.CookieStands.Include(x => x.hourlySale).FirstOrDefaultAsync(i => i.Id == id);

            if (cookieStandItem != null)
            {
                cookieStandItem.Location= updatedCookieStand.Location;
                cookieStandItem.Description = updatedCookieStand.Description;
                cookieStandItem.MinimumCustomersPerHour = updatedCookieStand.MinimumCustomersPerHour;
                cookieStandItem.MaximumCustomersPerHour = updatedCookieStand.MaximumCustomersPerHour;
                cookieStandItem.AverageCookiesPerSale = updatedCookieStand.AverageCookiesPerSale;
                cookieStandItem.Owner = updatedCookieStand.Owner;

                int max = (int)(cookieStandItem.MaximumCustomersPerHour * cookieStandItem.AverageCookiesPerSale);
                int min = (int)(cookieStandItem.MinimumCustomersPerHour * cookieStandItem.AverageCookiesPerSale);

                var random = new Random();

                var hours = await _cotext.hourlySales.Where(x => x.CookieStandId == cookieStandItem.Id).ToListAsync();

                foreach (var item in hours)
                {
                    item.SaleValue = random.Next(min, max);
                }

                await _cotext.SaveChangesAsync();

                var SaleperHour = await _cotext.hourlySales.Where(x => x.CookieStandId == cookieStandItem.Id).Select(s => s.SaleValue).ToListAsync();

                var CookieDto = new CookieStandViewDto
                {
                    Id = cookieStandItem.Id,
                    Location= cookieStandItem.Location,
                    Description = cookieStandItem.Description,
                    MinimumCustomersPerHour= cookieStandItem.MinimumCustomersPerHour,
                    MaximumCustomersPerHour= cookieStandItem.MaximumCustomersPerHour,
                    AverageCookiesPerSale=cookieStandItem.AverageCookiesPerSale,
                    Owner = cookieStandItem.Owner,
                    hourlySale= SaleperHour
                };

                return CookieDto;
            }

            return null;
        }
    }
}
