using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Migrator.Framework;

namespace ITS.DbMigration.RoadRepairing
{
    [Migration(201806041942)]
    public class Migration201806041942 : Migration
    {
        public override void Up()
        {
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_featureobject_fk");
            Database.RemoveForeignKey("rr_roadrepair", "rr_roadrepairaddressFK");
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_performerFK");
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_ownerFK");
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_customerFK");
            Database.RemoveTable("rr_roadrepair");
            Database.RemoveTable("rr_work_sort");
        }

        public override void Down()
        {

        }
    }
}
