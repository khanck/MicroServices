using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Lookups.DAL.Operations;
using Lookups.Model.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lookups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private IServiceProvider _serviceProvider;
        LookupRepository<Gender> lookupRepository;

        public GenderController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            lookupRepository = new LookupRepository<Gender>(_serviceProvider);
        }

        [ResponseType(typeof(Gender))]
        [Route("GetByID/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {            
            Gender gender = await lookupRepository.GetByIDAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return Ok(gender);
        }

        [ResponseType(typeof(Gender))]
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Gender> list = await lookupRepository.GetAllAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        protected void Dispose()
        {
            ((IDisposable)lookupRepository).Dispose();
        }
    }
}