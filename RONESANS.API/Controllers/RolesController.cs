using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.Role;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RONESANS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RolesController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;

        public RolesController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleRole.RuleGet();
                var GetAllRole = _uowRepositories.roleRepository.GetAllAsync().Result;
                var DTORoleGet = _uow.mapper.Map<List<Role>, List<DTORoleGet>>((List<Role>)GetAllRole);
                return Ok(DTORoleGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                _uowRules.ruleRole.RuleGetById(id);
                var GetRoleById = _uowRepositories.roleRepository.GetByID(id);
                var DTORoleGet = _uow.mapper.Map<Role, DTORoleGet>((Role)GetRoleById);
                return Ok(DTORoleGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST api/<RolesController>
        [HttpPost]
        public IActionResult Post([FromForm] DTORolePost DTORolePost)
        {

            try
            {
                var _Role = _uow.mapper.Map<DTORolePost, Role>(DTORolePost);
                _Role = _uowRules.ruleRole.RulePost(_Role);
                _uowRepositories.roleRepository.AddAsync(_Role);
                _uow.Complete();
                return Ok("Success Add");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] DTORolePut DTORolePut)
        {
            try
            {
                var _Role = _uow.mapper.Map<DTORolePut, Role>(DTORolePut);
                _Role = _uowRules.ruleRole.RulePut(id, _Role);
                _uowRepositories.roleRepository.update(_Role);
                _uow.Complete();
                return Ok("Success Update");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uowRules.ruleRole.RuleDelete(id);
                _uowRepositories.roleRepository.RemoveAsync(id);
                _uow.Complete();
                return Ok("Success Deleted");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
