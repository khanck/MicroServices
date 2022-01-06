using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using API.DAL.Core;
using Microsoft.AspNetCore.Mvc;
using API.Model.Core;

namespace APIs.Controllers
{
    /// <summary>
    /// Employees API for creating and modifying Employees details  
    /// </summary>


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IServiceProvider _serviceProvider;
        private EmployeesRepository employeesRepository;

        public EmployeesController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            employeesRepository = new EmployeesRepository(_serviceProvider);
        }
        //Get Employee details By EmployeeID
        [ResponseType(typeof(Employees))]
        [Route("GetByID/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(Guid id)
        {
            Employees employee = new EmployeesRepository(_serviceProvider).GetByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //Get All Employee details 
        [ResponseType(typeof(Employees))]
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await employeesRepository.GetAllAsync());
        }

        //Get Employee object for creating new Employee 
        //lookups will be getting from lookup APIs 
        [ResponseType(typeof(Employees))]
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            Employees employee = new Employees();
            return Ok(employee);
        }

        // create new Employee
        [ResponseType(typeof(Employees))]
        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (EmployeesRepository employeesRepo = new EmployeesRepository(_serviceProvider))
            {
                if (employeesRepo.IsAlreadyExists(employees))   // Duplicate checks 
                {
                    return Conflict();
                }
            }

            employees.ID = Guid.NewGuid();
            employeesRepository.Add(employees);
            employeesRepository.SaveChanges();
            return Ok(employees);
        }

        //Update existing Employee
        [ResponseType(typeof(Employees))]
        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (EmployeesRepository employeesRepo = new EmployeesRepository(_serviceProvider))
            {
                if (employeesRepo.GetByID(employees.ID) == null)
                {
                    return NotFound();
                }
            }
            using (EmployeesRepository employeesRepo = new EmployeesRepository(_serviceProvider))
            {
                if (employeesRepo.IsAlreadyExistsInOther(employees)) // Duplicate checks In Other
                {
                    return Conflict();
                }
            }

            employees = employeesRepository.Update(employees);
            employeesRepository.SaveChanges();
            return Ok(employees);
        }

        //Delete existing Employee by using EmployeeID
        [ResponseType(typeof(Employees))]
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Employees result = employeesRepository.Delete(id);
            employeesRepository.SaveChanges();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected void Dispose()
        {
            ((IDisposable)employeesRepository).Dispose();
        }

    }
}