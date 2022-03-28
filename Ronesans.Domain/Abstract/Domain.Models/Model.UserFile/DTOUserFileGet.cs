namespace Ronesans.Domain.Abstract.Domain.Models.Model.UserFile
{
    public class DTOUserFileGet
    {
        public virtual User.DTOUserGet User { get; set; }
        public virtual File.DTOFileGet File { get; set; }
    }
}
