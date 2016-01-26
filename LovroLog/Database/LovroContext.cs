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
    public class LovroContext : DbContext//, IDataAccess // WTF, nezgodno
    {
        public DbSet<LovroBaseEvent> BaseEvents { get; set; }
        public DbSet<LovroDiaperChangedEvent> DiaperChangedEvents { get; set; }
        public DbSet<DatabaseSummary> Summaries { get; set; }

        //public IEnumerable<LovroBaseEvent> GetBaseEvents()
        //{
        //    return this.BaseEvents;
        //}

        //public IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents()
        //{
        //    return this.DiaperChangedEvents;
        //}

        //public IEnumerable<DatabaseSummary> GetSummaries()
        //{
        //    return this.Summaries;
        //}

        //public LovroBaseEvent AddBaseEvent(LovroBaseEvent eventToAdd)
        //{
        //    LovroBaseEvent resultEvent = this.BaseEvents.Add(eventToAdd);
        //    this.SaveChanges();

        //    return resultEvent;
        //}

        public LovroContext(string connString)
            : base(connString)
        {
            Database.SetInitializer<LovroContext>(new DropCreateDatabaseIfModelChanges<LovroContext>());
        }
    }
}
 