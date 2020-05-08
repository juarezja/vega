using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using vega.Models;
using vega.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using vega.Controllers.Resources;
namespace vega.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }        
    }
}