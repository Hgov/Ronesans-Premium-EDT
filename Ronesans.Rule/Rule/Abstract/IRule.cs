using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ronesans.Rule.Rule.Abstract
{
    public interface IRule<TEntity> where TEntity:class
    {
        void RuleGet();
        void RuleGetById(int id);
        public TEntity RulePost(TEntity entity);
        TEntity RulePut(int id, TEntity entity);
        void RuleDelete(int id, string destination);
    }
}
