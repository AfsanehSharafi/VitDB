
namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }

}
