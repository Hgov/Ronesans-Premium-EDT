using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.UserFile;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.UnitOfWork.Concrete;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RONESANS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilesController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;

        public UserFilesController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<UserFilesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleUserFile.RuleGet();
                var GetUserWithFileAsync = _uowRepositories.userFileRepository.GetUserWithFileAsync().Result;
                var GetUserWithFile = _uow.mapper.Map<List<UserFile>, List<DTOUserFileGet>>(GetUserWithFileAsync.ToList());
                return Ok(GetUserWithFile);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<UserFilesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _uowRules.ruleUserFile.RuleGetById(id);
                var GetByIdUserAllAsync = _uowRepositories.userFileRepository.GetByIdUserWithFileAsync(id).Result;
                var DTOUserFileGet = _uow.mapper.Map<UserFile, DTOUserFileGet>(GetByIdUserAllAsync);
                return Ok(DTOUserFileGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST api/<UserFilesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserFilesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserFilesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
