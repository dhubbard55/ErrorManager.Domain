using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorManager.SqlServer.Models
{
    [Table("Error", Schema = "dbo")]
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }
        
        public int SeverityId { get; set; }

        public bool Enabled { get; set; }
        
        [ForeignKey("SeverityId")]
        public virtual Severity Severities { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}