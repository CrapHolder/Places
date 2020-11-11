using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace blessrng.Models
{
    public class StatusDbInitializer : DropCreateDatabaseAlways<ReqestDbContext>
    {
        //protected override void Seed(ReqestDbContext db)
        //{
        //    db.Statuses.Add(new Status { ID = 1, StatusName = "Л. Толстой" });
        //    db.Statuses.Add(new Status { ID = 2, StatusName = "И. Тургенев" });
        //    db.Statuses.Add(new Status { ID = 3, StatusName = "А. Чехов" });

        //    base.Seed(db);
        //}
    }
}