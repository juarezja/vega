using Microsoft.AspNetCore.Mvc;
using vega.Models;
using vega.Controllers.Resources;
using AutoMapper;
using vega.Persistence;
using System.Threading.Tasks;
namespace vega.Controllers
{
    [Route("/api/vehicles")]
    [ApiController]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            var vehicle=mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            return Ok(vehicle);
        }        
    }
}