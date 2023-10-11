using CookieStandApi.Models.DTOs;

namespace CookieStandApi.Models.Interfaces
{
    public interface ICookieStand
    {
        Task<CookieStandViewDto> Create(CookieStandDto cookieStand);

        Task<List<CookieStandViewDto>> GetAll();

        Task<CookieStandViewDto> GetById(int id);

        Task Delete(int id);

        Task<CookieStandViewDto> Update(int id, CookieStandDto updatedCookieStand);
    }
}
