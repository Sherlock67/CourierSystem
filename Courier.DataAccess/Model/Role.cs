using System.ComponentModel.DataAnnotations;

namespace Courier.DataAccess.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        public int? Sequence { get; set; }
        
        public bool? IsActive { get; set; }
    }
}
