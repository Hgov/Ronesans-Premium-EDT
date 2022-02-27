using Microsoft.AspNetCore.Mvc;
using Ronesans.Domain.Abstract.Domain.Models.Model.User;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Mapper.Abstract;
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
        private readonly RonesansDbContext _ronesansDbContext;
        private readonly IMapper _mapper;
        public UsersController(RonesansDbContext ronesansDbContext, IMapper mapper)
        {
            _ronesansDbContext = ronesansDbContext;
            _uow = new UnitOfWork(_ronesansDbContext);
            _mapper = mapper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _uow.ruleUser.RuleGet();
                var GetUserAll = _uow.userRepository.GetUserAll();
                var DTOUserGet = _mapper.Map<List<User>, List<DTOUserGet>>(GetUserAll.ToList());
                return Ok(DTOUserGet.Select(x => new DTOUserGet
                {
                    user_id = x.user_id,
                    first_name = x.first_name,
                    last_name = x.last_name,
                    role_id = x.role_id,
                    Role = x.Role,
                    email = x.email,
                    phone = x.phone,
                    password = x.password,
                    gender_id = x.gender_id,
                    Gender = x.Gender,
                    UserFiles = x.UserFiles,
                    bio = x.bio,
                    status_active = x.status_active,
                    status_visibility = x.status_visibility,
                    creation_tsz = x.creation_tsz,
                    last_updated_tsz = x.last_updated_tsz,
                    delete_tsz = x.delete_tsz
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
                _uow.ruleUser.RuleGetById(id);
                var GetByIdUserAll = _uow.userRepository.GetByIdUserAll(id);
                var DTOUserGet = _mapper.Map<User, DTOUserGet>(GetByIdUserAll);
                return Ok(new
                {
                    user_id = DTOUserGet.user_id,
                    first_name = DTOUserGet.first_name,
                    last_name = DTOUserGet.last_name,
                    role_id = DTOUserGet.role_id,
                    Role = DTOUserGet.Role,
                    email = DTOUserGet.email,
                    phone = DTOUserGet.phone,
                    password = DTOUserGet.password,
                    gender_id = DTOUserGet.gender_id,
                    Gender = DTOUserGet.Gender,
                    UserFiles=DTOUserGet.UserFiles,
                  //  image_src = string.Format("{0}://{1}{2}/Files/image/" + DTOUserGet.UserFiles.destination_name + "/{3}", Request.Scheme, Request.Host, Request.PathBase, DTOUserGet.UserFiles.file_name),
                    bio = DTOUserGet.bio,
                    status_active = DTOUserGet.status_active,
                    status_visibility = DTOUserGet.status_visibility,
                    creation_tsz = DTOUserGet.creation_tsz,
                    last_updated_tsz = DTOUserGet.last_updated_tsz,
                    delete_tsz = DTOUserGet.delete_tsz
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
                var _user = _mapper.Map<DTOUserPost, User>(DTOUserPost);
                _user = _uow.ruleUser.RulePost(_user);

                var _file = _mapper.Map<DTOUserPost, File>(DTOUserPost);
                _file.destination_name = ControllerContext.ActionDescriptor.ControllerName;
                _file= _uow.ruleFile.RulePost(_file);

                
                _uow.userFileRepository.Add(new UserFile
                {
                    User = _user,
                    File = _file
                });

                _uow.fileCreate.UploadFile(_file);
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
                var _user = _mapper.Map<DTOUserPut, User>(DTOUserPut);
                _user = _uow.ruleUser.RulePut(id, _user);
                _uow.userRepository.update(_user);



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
                _uow.ruleUser.RuleDelete(id, ControllerContext.ActionDescriptor.ControllerName);
                _uow.userRepository.Remove(id);
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
