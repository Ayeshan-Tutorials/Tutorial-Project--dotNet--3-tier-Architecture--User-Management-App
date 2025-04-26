using BusinessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _employeeRepository.GetAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _employeeRepository.GetByIdAsync(id);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employeeDto)
        {
            var result = await _employeeRepository.AddAsync(employeeDto);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        {
            var result = await _employeeRepository.UpdateAsync(employeeDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeRepository.DeleteAsync(id);
            return Ok(result);
        }
        
    }
}
