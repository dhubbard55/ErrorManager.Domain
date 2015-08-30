using ErrorManager.SqlServer.Models;
using System.Data.Common;
using System.Data.Entity;

namespace ErrorManager.Domain.SqlServer
{
    public class ErrorManagerContext : DbContext
    {
        public ErrorManagerContext(DbConnection connect, bool ownsConnection)
            : base(connect, ownsConnection)
        {
            Database.SetInitializer<ErrorManagerContext>(null);
        }
        
        public DbSet<Error> Errors { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }        
    }
}
