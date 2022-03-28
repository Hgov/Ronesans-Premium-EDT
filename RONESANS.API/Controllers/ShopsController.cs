using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.Shop;
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
    [Produces("application/json")]
    public class ShopsController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;

        public ShopsController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<ShopsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleShop.RuleGet();
                var GetShopAll = _uowRepositories.shopRepository.GetShopAllAsync().Result;
                var DTOShopGet = _uow.mapper.Map<List<Shop>, List<DTOShopGet>>(GetShopAll.ToList());
                return Ok(DTOShopGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<ShopsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _uowRules.ruleShop.RuleGetById(id);
                var GetByIdShopAll = _uowRepositories.shopRepository.GetByIdShopAllAsync(id).Result;
                var DTOShopGet = _uow.mapper.Map<Shop, DTOShopGet>(GetByIdShopAll);
                return Ok(DTOShopGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST api/<ShopsController>
        [HttpPost]
        public IActionResult Post([FromForm] DTOShopPost DTOShopPost)
        {

            try
            {
                var _shop = _uow.mapper.Map<DTOShopPost, Shop>(DTOShopPost);
                _shop = _uowRules.ruleShop.RulePost(_shop);
                _uowRepositories.shopRepository.AddAsync(_shop);
                _uow.Complete();
                return Ok("Success Add");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<ShopsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] DTOShopPut DTOShopPut)
        {
            try
            {
                var _shop = _uow.mapper.Map<DTOShopPut, Shop>(DTOShopPut);
                _shop = _uowRules.ruleShop.RulePut(id, _shop);
                _uowRepositories.shopRepository.update(_shop);
                _uow.Complete();
                return Ok("Success Update");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<ShopsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uowRules.ruleShop.RuleDelete(id);
                _uowRepositories.shopRepository.RemoveAsync(id);
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
