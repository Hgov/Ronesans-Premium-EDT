using Ronesans.Domain.Access.Abstract.IRepository;
using File = Ronesans.Domain.Concrete.Domain.File;
using System;
using Ronesans.Mapper.Abstract;

namespace Ronesans.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IMapper mapper { get; }
        IFileCreate<File> fileCreate { get; }
        int Complete();

    }
}
