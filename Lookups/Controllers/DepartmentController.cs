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
    public class DepartmentController : ControllerBase
    {
        private IServiceProvider _serviceProvider;
        LookupRepository<Department> lookupRepository;

        public DepartmentController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            lookupRepository = new LookupRepository<Department>(_serviceProvider);
        }

        [ResponseType(typeof(Department))]
        [Route("GetByID/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {           
            Department department = await lookupRepository.GetByIDAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [ResponseType(typeof(Department))]
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Department> list =await lookupRepository.GetAllAsync();
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