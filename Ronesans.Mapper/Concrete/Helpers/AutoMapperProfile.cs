using AutoMapper;
using Ronesans.Domain.Abstract.Domain.Models.Model.City;
using Ronesans.Domain.Abstract.Domain.Models.Model.File;
using Ronesans.Domain.Abstract.Domain.Models.Model.Gender;
using Ronesans.Domain.Abstract.Domain.Models.Model.Role;
using Ronesans.Domain.Abstract.Domain.Models.Model.Shop;
using Ronesans.Domain.Abstract.Domain.Models.Model.ShopFile;
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
            //user
            CreateMap<DTOUserGet, User>();
            CreateMap<User, DTOUserGet>();

            CreateMap<DTOUserPost, User>();
            CreateMap<User, DTOUserPost>();

            CreateMap<DTOUserPut, User>();
            CreateMap<User, DTOUserPut>();

            CreateMap<DTOUserPost, File>();
            CreateMap<File, DTOUserPost>();

            CreateMap<DTOUserPut, File>();
            CreateMap<File, DTOUserPut>();
            //role
            CreateMap<DTORoleGet, Role>();
            CreateMap<Role, DTORoleGet>();

            CreateMap<DTORolePost, Role>();
            CreateMap<Role, DTORolePost>();

            CreateMap<DTORolePut, Role>();
            CreateMap<Role, DTORolePut>();

            //City
            CreateMap<DTOCityGet, City>();
            CreateMap<City, DTOCityGet>();

            CreateMap<DTOCityPost, City>();
            CreateMap<City, DTOCityPost>();

            CreateMap<DTOCityPut, City>();
            CreateMap<City, DTOCityPut>();

            //gender
            CreateMap<DTOGenderGet, Gender>();
            CreateMap<Gender, DTOGenderGet>();

            CreateMap<DTOGenderPost, Gender>();
            CreateMap<Gender, DTOGenderPost>();

            CreateMap<DTOGenderPut, Gender>();
            CreateMap<Gender, DTOGenderPut>();
            //file
            CreateMap<DTOFileGet, File>();
            CreateMap<File, DTOFileGet>();

            CreateMap<DTOFilePost, File>();
            CreateMap<File, DTOFilePost>();

            CreateMap<DTOFilePut, File>();
            CreateMap<File, DTOFilePut>();
            //userfile
            //CreateMap<DTOUserPost, UserFile>();
            //CreateMap<DTOUserPost, ICollection<UserFile>>();

            CreateMap<File, UserFile>();
            CreateMap<UserFile, File>();

            CreateMap<DTOUserFileGet, File>();
            CreateMap<File, DTOUserFileGet>();

            CreateMap<DTOUserFileGet, UserFile>();
            CreateMap<UserFile, DTOUserFileGet>();
            //shop
            CreateMap<DTOShopGet, Shop>();
            CreateMap<Shop, DTOShopGet>();

            CreateMap<DTOShopPost, Shop>();
            CreateMap<Shop, DTOShopPost>();

            CreateMap<DTOShopPut, Shop>();
            CreateMap<Shop, DTOShopPut>();

            //ShopFile
            CreateMap<DTOShopPost, ShopFile>();
            CreateMap<DTOShopPost, ICollection<ShopFile>>();

            CreateMap<File, ShopFile>();
            CreateMap<ShopFile, File>();

            CreateMap<DTOShopFileGet, File>();
            CreateMap<File, DTOShopFileGet>();

            CreateMap<DTOShopFileGet, ShopFile>();
            CreateMap<ShopFile, DTOShopFileGet>();

        }
    }
}
