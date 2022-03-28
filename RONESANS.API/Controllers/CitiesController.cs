using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.City;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.UnitOfWork.Concrete;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RONESANS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CitiesController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;

        public CitiesController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<CitiesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleCity.RuleGet();
                var GetAllCity = _uowRepositories.cityRepository.GetAllAsync().Result;
                var DTOCityGet = _uow.mapper.Map<List<City>, List<DTOCityGet>>((List<City>)GetAllCity);
                return Ok(DTOCityGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                _uowRules.ruleCity.RuleGetById(id);
                var GetCityById = _uowRepositories.cityRepository.GetByID(id);
                var DTOCityGet = _uow.mapper.Map<City, DTOCityGet>((City)GetCityById);
                return Ok(DTOCityGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST api/<CitiesController>
        [HttpPost]
        public IActionResult Post([FromForm] DTOCityPost DTOCityPost)
        {

            try
            {
                var _City = _uow.mapper.Map<DTOCityPost, City>(DTOCityPost);
                _City = _uowRules.ruleCity.RulePost(_City);
                _uowRepositories.cityRepository.AddAsync(_City);
                _uow.Complete();
                return Ok("Success Add");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] DTOCityPut DTOCityPut)
        {
            try
            {
                var _City = _uow.mapper.Map<DTOCityPut, City>(DTOCityPut);
                _City = _uowRules.ruleCity.RulePut(id, _City);
                _uowRepositories.cityRepository.update(_City);
                _uow.Complete();
                return Ok("Success Update");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uowRules.ruleCity.RuleDelete(id);
                _uowRepositories.cityRepository.RemoveAsync(id);
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
