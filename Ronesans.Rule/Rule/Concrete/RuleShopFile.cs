using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleShopFile : IRule<ShopFile>
    {
        public RuleShopFile()
        {
                
        }
        public void RuleDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void RuleGet()
        {
            throw new NotImplementedException();
        }

        public void RuleGetById(int id)
        {
            throw new NotImplementedException();
        }

        public ShopFile RulePost(ShopFile entity)
        {
            throw new NotImplementedException();
        }

        public ShopFile RulePut(int id, ShopFile entity)
        {
            throw new NotImplementedException();
        }
    }
}
