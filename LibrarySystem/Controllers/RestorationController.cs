using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestorationController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IRestorationService _restorationService;
        public RestorationController(ApplicationDbContext context , IRestorationService restorationService)
        {
            _context = context;
            _restorationService = restorationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllRestorations()
        {
            var restorations = await _restorationService.GetAllRestorations();
            return Ok(restorations);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddRestoration(int id)
        {
            var restoration = await _restorationService.AddRestoration(id);
            if(restoration == false)
                return Ok(" Restoration  wrong! please try again");

            return Ok(" Restoration done successfully");

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRestoration(int id)
        {

            var restoration = await _restorationService.DeleteRestoration(id);
            if (restoration == false)
                return Ok(" Restoration delete wrong! please try again");

            return Ok(" Restoration done successfully");
        }


    }
}
