using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.File;
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
    public class FilesController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;

        public FilesController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<FilesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleFile.RuleGet();
                var GetAllFile = _uowRepositories.fileRepository.GetAllAsync().Result;
                var DTOFileGet = _uow.mapper.Map<List<File>, List<DTOFileGet>>((List<File>)GetAllFile);
                return Ok(DTOFileGet);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<FilesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            _uowRules.ruleFile.RuleGetById(id);
            var GetFileById = _uowRepositories.fileRepository.GetByID(id);
            var DTOFileGet = _uow.mapper.Map<File, DTOFileGet>((File)GetFileById);
            return Ok(DTOFileGet);
        }

        // POST api/<FilesController>
        [HttpPost]
        public IActionResult Post([FromForm] DTOFilePost DTOFilePost)
        {

            try
            {
                var _file = _uow.mapper.Map<DTOFilePost, File>(DTOFilePost);
                _file.destination_name = ControllerContext.ActionDescriptor.ControllerName;
                _file = _uowRules.ruleFile.RulePost(_file);
                _uowRepositories.fileRepository.AddAsync(_file);
                _uow.fileCreate.UploadFile(_file);
                _uow.Complete();
                return Ok("Success Add");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<FilesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] DTOFilePut DTOFilePut)
        {
            try
            {
                var _file = _uow.mapper.Map<DTOFilePut, File>(DTOFilePut);
                _file.destination_name = ControllerContext.ActionDescriptor.ControllerName;
               
                _file = _uowRules.ruleFile.RulePut(id, _file);
                _uowRepositories.fileRepository.update(_file);
                _uow.fileCreate.UploadFile(_file);
                _uow.Complete();

                return Ok("Success Update");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<FilesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uowRules.ruleFile.RuleDelete(id);
                _uow.fileCreate.DeleteFile(_uowRepositories.fileRepository.GetByID(id));
                _uowRepositories.fileRepository.RemoveAsync(id);
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
