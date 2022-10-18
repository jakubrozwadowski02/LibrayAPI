
namespace LibrayAPI.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
