
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorManager.SqlServer.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public int? AddressId { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(254)]
        public string Email { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public virtual ICollection<UserNotification> AssignedNotifies { get; set; }
    }
}