using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using vega.Models;
using ve.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        public MakesController(VegaDbContext context)
        {
            this.context = context;
        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}