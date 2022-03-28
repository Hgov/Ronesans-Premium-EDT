using Ronesans.Domain.Abstract.Domain.Models.Model.File;
using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using Ronesans.Domain.Concrete.Domain;
using Ronesans.Mapper.Abstract;
using Ronesans.Rule.Rule.Abstract;
using System;

namespace Ronesans.Rule.Rule.Concrete
{
    public class RuleFile : IRule<File>
    {
        private IFileRepository _fileRepository;
        private IFileCreate<File> _fileCreate;
        public RuleFile(IFileRepository fileRepository, IFileCreate<File> fileCreate)
        {
            _fileRepository = fileRepository;
            _fileCreate = fileCreate;
        }

        public void RuleDelete(int id)
        {
            var _file = _fileRepository.GetByID(id);
            if (_file == null)
                throw new AppException("File Not Found.");
        }

        public void RuleGet()
        {

        }

        public void RuleGetById(int id)
        {

        }

        public File RulePost(File file)
        {
            var extension = "." + file.from_file.FileName.Split('.')[file.from_file.FileName.Split('.').Length - 1];
            return file = new File
            {
                content_type = file.from_file.ContentType,
                file_name = file.from_file.FileName.Substring(0, file.from_file.FileName.IndexOf(".")) + "-" + DateTime.Now.ToString("yymmssfff") + extension, //Create a new Name,
                length = file.from_file.Length,
                destination_name = file.destination_name,
                from_file = file.from_file
            };
        }

        public File RulePut(int id, File file)//düzenlencek
        {
            if (file.from_file == null)
                throw new AppException("No file selected.");
            var _file = _fileRepository.GetByID(id);
            if (_file == null)
                throw new AppException("File not found");

            _fileCreate.DeleteFile(_file);
            var extension = "." + file.from_file.FileName.Split('.')[file.from_file.FileName.Split('.').Length - 1];
            _file.content_type = file.from_file.ContentType;
            _file.file_name = file.from_file.FileName.Substring(0, file.from_file.FileName.IndexOf(".")) + "-" + DateTime.Now.ToString("yymmssfff") + extension; //Create a new Name,
            _file.length = file.from_file.Length;
            _file.destination_name = file.destination_name;
            _file.from_file = file.from_file;
            return _file;
        }
    }
}
