using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.User;
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
    public class UsersController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly UnitOfWorkRepositories _uowRepositories;
        private readonly UnitOfWorkRules _uowRules;
        private readonly RonesansDbContext _ronesansDbContext;
       
        public UsersController(RonesansDbContext ronesansDbContext)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _uowRepositories = new UnitOfWorkRepositories(_ronesansDbContext);
            _uowRules = new UnitOfWorkRules(_ronesansDbContext);
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uowRules.ruleUser.RuleGet();
                var GetUserAll = _uowRepositories.userRepository.GetUserAllAsync().Result;
                var DTOUserGet = _uow.mapper.Map<List<User>, List<DTOUserGet>>(GetUserAll.ToList());
                return Ok(DTOUserGet.Select(x=>new {
                    user_id = x.user_id,
                    role_id = x.role_id,
                    Role = x.Role,
                    gender_id = x.gender_id,
                    Gender = x.Gender,
                    //UserFiles = x.UserFiles,
                    //image_src = string.Format("{0}://{1}{2}{3}/{4}/{5}",
                    //Request.Scheme,
                    //Request.Host,
                    //"/Files/",
                    //x.UserFiles.Select(y => y.File.content_type.Substring(0, y.File.content_type.IndexOf("/"))).FirstOrDefault(),
                    //x.UserFiles.Select(y => y.File.destination_name).FirstOrDefault(),
                    //x.UserFiles.Select(y => y.File.file_name).FirstOrDefault()),
                    first_name = x.first_name,
                    last_name = x.last_name,
                    password = x.password,
                    email = x.email,
                    phone = x.phone,
                    bio = x.bio,
                    creation_tsz = x.creation_tsz,
                    status_active = x.status_active,
                    status_visibility = x.status_visibility
                }));
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _uowRules.ruleUser.RuleGetById(id);
                var GetByIdUserAll = _uowRepositories.userRepository.GetByIdUserAllAsync(id).Result;
                var DTOUserGet = _uow.mapper.Map<User, DTOUserGet>(GetByIdUserAll);
                return Ok(new
                {
                    user_id = DTOUserGet.user_id,
                    role_id = DTOUserGet.role_id,
                    Role = DTOUserGet.Role,
                    gender_id = DTOUserGet.gender_id,
                    Gender = DTOUserGet.Gender,
                    //UserFiles = DTOUserGet.UserFiles,
                   // image_src = string.Format("{0}://{1}{2}{3}/{4}/{5}",
                   // Request.Scheme,
                   // Request.Host,
                   // "/Files/",
                   // DTOUserGet.UserFiles.Select(y => y.File.content_type.Substring(0, y.File.content_type.IndexOf("/"))).FirstOrDefault(),
                   // DTOUserGet.UserFiles.Select(y => y.File.destination_name).FirstOrDefault(),
                   // DTOUserGet.UserFiles.Select(y => y.File.file_name).FirstOrDefault()),
                    first_name = DTOUserGet.first_name,
                    last_name = DTOUserGet.last_name,
                    password = DTOUserGet.password,
                    email = DTOUserGet.email,
                    phone = DTOUserGet.phone,
                    bio = DTOUserGet.bio,
                    creation_tsz = DTOUserGet.creation_tsz,
                    status_active = DTOUserGet.status_active,
                    status_visibility = DTOUserGet.status_visibility
                });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromForm] DTOUserPost DTOUserPost)
        {

            try
            {
                var _user = _uow.mapper.Map<DTOUserPost, User>(DTOUserPost);
                _user = _uowRules.ruleUser.RulePost(_user);

                //var _file = _uow.mapper.Map<DTOUserPost, File>(DTOUserPost);
                //_file.destination_name = ControllerContext.ActionDescriptor.ControllerName;
                //_file = _uowRules.ruleUserFile.RulePost(_file);

                //_uow.userFileRepository.AddAsync(new UserFile
                //{
                //    User = _user,
                //    File = _file
                //});

                //_uow.fileCreate.UploadFile(_file);
                _uowRepositories.userRepository.AddAsync(_user);
                _uow.Complete();
                return Ok("Success Add");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] DTOUserPut DTOUserPut)
        {
            try
            {
                var _user = _uow.mapper.Map<DTOUserPut, User>(DTOUserPut);
                _user = _uowRules.ruleUser.RulePut(id, _user);
                //if (DTOUserPut.from_file != null)
                //{
                //    var _file = _uow.mapper.Map<DTOUserPut, File>(DTOUserPut);
                //    _file.destination_name = ControllerContext.ActionDescriptor.ControllerName;
                //    _file.file_id = _uow.userFileRepository.GetByUserId(_user.user_id).file_id;
                //    _file = _uowRules.ruleUserFile.RulePut(_file.file_id, _file);
                //    _uow.userFileRepository.update(new UserFile
                //    {
                //        User = _user,
                //        File = _file
                //    });

                //    _uow.fileCreate.UploadFile(_file);
                //}
                _uowRepositories.userRepository.update(_user);
                _uow.Complete();
                return Ok("Success Update");
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uowRules.ruleUser.RuleDelete(id);
                _uowRepositories.userRepository.RemoveAsync(id);

                //var file =_uowRepositories.fileRepository.GetByID(_uowRepositories.userFileRepository.GetByUserId(id).file_id);
                //if (file != null)
                //{
                //    _uowRepositories.fileRepository.RemoveAsync(file.file_id);
                //    _uow.fileCreate.DeleteFile(file);
                //}

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
