using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IFileCreate<TEntity> where TEntity : class
    {
        Task<string> UploadFile(TEntity entity);
        void DeleteFile(TEntity entity);
    }
}
