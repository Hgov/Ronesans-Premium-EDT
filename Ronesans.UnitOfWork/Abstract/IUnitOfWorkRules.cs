using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;

namespace Ronesans.UnitOfWork.Abstract
{
   public interface IUnitOfWorkRules  : IDisposable
    {
        IRule<User> ruleUser { get; }
        IRule<Shop> ruleShop { get; }
        IRule<File> ruleFile { get; }
        IRule<UserFile> ruleUserFile { get; }
        IRule<Gender> ruleGender { get; }
        IRule<City> ruleCity { get; }
        IRule<Role> ruleRole { get; }
        int Complete();
    }
}
