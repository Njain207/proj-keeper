using Microsoft.EntityFrameworkCore;

namespace PortFolioTracker.Models
{
   
    public partial class MvcPortFolioContext : DbContext
    {
        public MvcPortFolioContext()
        { }
        public MvcPortFolioContext(DbContextOptions<MvcPortFolioContext> options)
            : base(options)
        { }
        public virtual DbSet<Login>? Logins { get; set; }
    }
}
