using LovroLog.Database;
using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog
{
    public class LovroContext : DbContext
    {
        public DbSet<LovroBaseEvent> BaseEvents { get; set; }
        public DbSet<LovroDiaperChangedEvent> DiaperChangedEvents { get; set; }
        public DbSet<DatabaseSummary> Summaries { get; set; }

        public LovroContext(string connString)
            : base(connString)
        {
            System.Data.Entity.Database.SetInitializer<LovroContext>(new DropCreateDatabaseIfModelChanges<LovroContext>());
        }
    }
}
 