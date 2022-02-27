using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Rule.Rule.Abstract;
using System;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleFile : IRule<File>
    {
        private IFileRepository _fileRepository;
        public RuleFile(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public void RuleDelete(int id, string destination)
        {
            throw new System.NotImplementedException();
        }

        public void RuleGet()
        {
            throw new System.NotImplementedException();
        }

        public void RuleGetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public File RulePost(File file)
        {
            var extension = "." + file.from_file.FileName.Split('.')[file.from_file.FileName.Split('.').Length - 1];
            return file = new File{ 
            content_type=file.from_file.ContentType,
            file_name = file.from_file.FileName.Substring(0, file.from_file.FileName.IndexOf(".")) + "-" + DateTime.Now.ToString("yymmssfff") + extension, //Create a new Name,
            length =file.from_file.Length,
            destination_name=file.destination_name,
            from_file=file.from_file
            };
        }

        public File RulePut(int id, File file)
        {
            throw new System.NotImplementedException();
        }
    }
}
