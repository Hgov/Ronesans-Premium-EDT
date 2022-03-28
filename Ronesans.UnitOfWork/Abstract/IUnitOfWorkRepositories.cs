using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Mapper.Abstract;
using System;

namespace Ronesans.UnitOfWork.Abstract
{
   public interface IUnitOfWorkRepositories : IDisposable
    {
        IUserRepository userRepository { get; }
        IFileRepository fileRepository { get; }
        IUserFileRepository userFileRepository { get; }
        IGenderRepository genderRepository { get; }
        ICityRepository cityRepository { get; }
        IRoleRepository roleRepository { get; }
        IShopRepository shopRepository { get; }
        IShopFileRepository shopFileRepository { get; }
        int Complete();
    }
}
