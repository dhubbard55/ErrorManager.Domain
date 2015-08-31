using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorManager.SqlServer.Models
{
    [Table("Notification", Schema = "dbo")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}