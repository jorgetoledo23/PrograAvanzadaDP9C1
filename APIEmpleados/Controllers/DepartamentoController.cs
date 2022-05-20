using APIEmpleados.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEmpleados.Controllers
{
    [Authorize(Roles = "Free")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class DepartamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Departamento>>> GetAllDepartments()
        {
            var Departments = _context.Departamentos.ToList();
            return Ok(Departments);
        }

        [HttpGet]
        [Route("GetDeparmentById")]
        public async Task<ActionResult<Departamento>> GetDepartmentById(int id)
        {
            var Department = _context.Departamentos
                .FirstOrDefault(dept => dept.DepartamentoId == id);
            return Ok(Department);
        }

        [HttpPost]
        [Route("AddDepartment")]
        [Authorize(Roles = "Free")]
        public async Task<ActionResult> AddDeparment(DepartamentoDTO deptDTO)
        {
            if (deptDTO == null) return BadRequest();
            var departamento = new Departamento()
            {
                CompanyNo = deptDTO.CompanyNo,
                Descripcion = deptDTO.Descripcion
            };
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("UptDepartment")]
        public async Task<ActionResult> UptDeparment(DepartamentoDTO deptDTO)
        {
            if (deptDTO == null) return BadRequest();
            var departamento = new Departamento()
            {
                DepartamentoId = deptDTO.Id,
                CompanyNo = deptDTO.CompanyNo,
                Descripcion = deptDTO.Descripcion
            };
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DelDepartment")]
        public async Task<ActionResult> DelDeparment(DepartamentoDTO deptDTO)
        {
            if (deptDTO == null) return BadRequest();
            var dpto = _context.Departamentos
                .FirstOrDefault(d => d.DepartamentoId == deptDTO.Id);
            _context.Departamentos.Remove(dpto);
            await _context.SaveChangesAsync();
            return Ok();
        }













    }
}
