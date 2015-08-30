using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorManager.SqlServer.Models
{
    [Table("UserNotification", Schema = "dbo")]
    public class UserNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ErrorId { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }

        public int? Frequency { get; set; }

        [ForeignKey("ErrorId")]
        public virtual Error Error { get; set; }

        [ForeignKey("NotificationId")]
        public virtual Notification Notification { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}