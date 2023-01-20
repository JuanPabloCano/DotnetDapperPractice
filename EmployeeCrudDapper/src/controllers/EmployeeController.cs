using AutoMapper;
using EmployeeCrudDapper.entities;
using EmployeeCrudDapper.entities.dtos;
using EmployeeCrudDapper.services.gateways;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrudDapper.controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IBaseService<Employee, int> _baseService;
    private readonly IMapper _mapper;

    public EmployeeController(IBaseService<Employee, int> baseService, IMapper mapper)
    {
        _baseService = baseService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Get()
    {
        try
        {
            var employees = await _baseService.GetAll();
            return Ok(employees);
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }

    [HttpGet("deleted")]
    public async Task<ActionResult<List<Employee>>> GetAllDeleted()
    {
        try
        {
            var employees = await _baseService.GetAllDeleted();
            return Ok(employees);
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var employee = await _baseService.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Post([FromBody] EmployeeDto employeeDto)
    {
        try
        {
            var mappedEmployee = _mapper.Map<Employee>(employeeDto);
            await _baseService.Create(mappedEmployee);
            mappedEmployee.IsActive = true;
            return Created("", mappedEmployee);
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Employee>> Patch([FromBody] EmployeeDto employeeDto, int id)
    {
        try
        {
            var selectedEmployee = await GetById(id);
            if (selectedEmployee is null)
            {
                return NotFound();
            }

            var mappedEmployee = _mapper.Map<Employee>(employeeDto);
            await _baseService.Update(id, mappedEmployee);
            return Ok(mappedEmployee);
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, [FromBody] DeleteEmployeeDto deleteEmployeeDto)
    {
        try
        {
            var mappedEmployee = _mapper.Map<Employee>(deleteEmployeeDto);
            await _baseService.Delete(mappedEmployee, id);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }
}