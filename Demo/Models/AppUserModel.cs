using Microsoft.AspNetCore.Identity;

namespace Demo.Models
{
    public class AppUserModel : IdentityUser
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int BirthYear { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string RoleId { get; set; }
    }
}
