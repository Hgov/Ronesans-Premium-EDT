using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.Gender;
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
    public class GendersController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;

        public GendersController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<GendersController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleGender.RuleGet();
                var GetAllGender = _uowRepositories.genderRepository.GetAllAsync().Result;
                var DTOGenderGet = _uow.mapper.Map<List<Gender>, List<DTOGenderGet>>((List<Gender>)GetAllGender);
                return Ok(DTOGenderGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<GendersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
            _uowRules.ruleGender.RuleGetById(id);
            var GetGenderById = _uowRepositories.genderRepository.GetByID(id);
            var DTOGenderGet = _uow.mapper.Map<Gender, DTOGenderGet>((Gender)GetGenderById);
            return Ok(DTOGenderGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST api/<GendersController>
        [HttpPost]
        public IActionResult Post([FromForm] DTOGenderPost DTOGenderPost)
        {

            try
            {
                var _gender = _uow.mapper.Map<DTOGenderPost, Gender>(DTOGenderPost);
                _gender = _uowRules.ruleGender.RulePost(_gender);
                _uowRepositories.genderRepository.AddAsync(_gender);
                _uow.Complete();
                return Ok("Success Add");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<GendersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] DTOGenderPut DTOGenderPut)
        {
            try
            {
                var _Gender = _uow.mapper.Map<DTOGenderPut, Gender>(DTOGenderPut);
                _Gender = _uowRules.ruleGender.RulePut(id, _Gender);
                _uowRepositories.genderRepository.update(_Gender);
                _uow.Complete();
                return Ok("Success Update");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<GendersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uowRules.ruleGender.RuleDelete(id);
                _uowRepositories.genderRepository.RemoveAsync(id);
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
