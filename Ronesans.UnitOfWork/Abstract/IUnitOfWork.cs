using Ronesans.Domain.Access.Abstract.IRepository;
using File=Ronesans.Domain.Concrete.Domain.File;
using System;
using Ronesans.Rule.Rule.Abstract;
using Ronesans.Domain.Concrete.Domain;

namespace Ronesans.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IFileRepository fileRepository { get; }
        IUserFileRepository userFileRepository { get; }
        IFileCreate<File> fileCreate { get; }
        IRule<User> ruleUser { get; } 
        IRule<File> ruleFile { get; }
        int Complete();

    }
}
