using AutoMapper;
using Ronesans.Domain.Abstract.Domain.Models.Model.File;
using Ronesans.Domain.Abstract.Domain.Models.Model.Gender;
using Ronesans.Domain.Abstract.Domain.Models.Model.Role;
using Ronesans.Domain.Abstract.Domain.Models.Model.Shop;
using Ronesans.Domain.Abstract.Domain.Models.Model.User;
using Ronesans.Domain.Abstract.Domain.Models.Model.UserFile;
using Ronesans.Domain.Concrete.Domain;
using System.Collections.Generic;

namespace Ronesans.Mapper.Concrete.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DTOUserGet, User>();
            CreateMap<User, DTOUserGet>();

            CreateMap<DTOUserPost, User>();
            CreateMap<User, DTOUserPost>();

            CreateMap<DTOUserPut, User>();
            CreateMap<User, DTOUserPut>();

            CreateMap<DTORoleGet, Role>();
            CreateMap<Role, DTORoleGet>();

            CreateMap<DTOGenderGet, Gender>();
            CreateMap<Gender, DTOGenderGet>();

            CreateMap<DTOUserPost, File>();
            CreateMap<File, DTOUserPost>();


            CreateMap<DTOUserFileGet, UserFile>();
            CreateMap<UserFile, DTOUserFileGet>();

            CreateMap<DTOFileGet, File>();
            CreateMap<File, DTOFileGet>();

            CreateMap<DTOUserFileGet, File>();
            CreateMap<File, DTOUserFileGet>();


        }
    }
}
