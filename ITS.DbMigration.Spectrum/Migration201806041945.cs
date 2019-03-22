using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Migrator.Framework;

namespace ITS.DbMigration.RoadRepairing
{
    [Migration(201806041945)]
   public class Migration201806041945 : Migration
    {
        public override void Up()
        {
            Database.AddTable("rr_roadrepair",
                new Column[]
                {
                    new Column("id", DbType.Int64, ColumnProperty.PrimaryKey),
                    //new Column("address_id", DbType.Int64),
                    new Column("note", DbType.String, 511),
                    new Column("status", DbType.String),
                    new Column("repair_type", DbType.String),
                    new Column("work_type", DbType.String),
                    new Column("work_sort", DbType.String),
                    new Column("repair_start", DbType.Date),
                    new Column("repair_end", DbType.Date),
                    new Column("repair_start_fact", DbType.Date),
                    new Column("repair_end_fact", DbType.Date),
                    new Column("performer_id", DbType.Int64),
                    new Column("owner_id", DbType.Int64),
                    new Column("customer_id", DbType.Int64),
                    new Column("feature_object_id", DbType.Int64, ColumnProperty.NotNull)

                });

            Database.AddTable("rr_address_roadrepair", new[]
            {
                new Column("roadrepair_id", DbType.Int64, ColumnProperty.NotNull),
                new Column("address_id", DbType.Int64, ColumnProperty.NotNull)
            });

           
            Database.AddForeignKey("rr_address_roadrepair_to_roadrepair_fk", "rr_address_roadrepair", "roadrepair_id", "rr_roadrepair", "id", Migrator.Framework.ForeignKeyConstraint.Cascade);
            Database.AddForeignKey("rr_address_roadrepair_to_address_fk", "rr_address_roadrepair", "address_id", "addresses", "id", Migrator.Framework.ForeignKeyConstraint.Cascade);

            Database.AddTable("rr_work_sort", new[]
            {
                new Column("id",DbType.Int64,ColumnProperty.PrimaryKey),
                new Column("repair_type",DbType.Int16),
                new Column("work_type",DbType.Int16),
                new Column("description",DbType.String)
            });

          
            Database.AddForeignKey("roadrepair_featureobjectFK", "rr_roadrepair", "feature_object_id", "featureobject", "id");
            Database.AddForeignKey("roadrepair_performerFK", "rr_roadrepair", "performer_id",
                "info_organization", "id");
            Database.AddForeignKey("roadrepair_ownerFK", "rr_roadrepair", "owner_id",
                "info_organization", "id");
            Database.AddForeignKey("roadrepair_customerFK", "rr_roadrepair", "customer_id",
                "info_organization", "id");

            //Database.Insert("rr_work_sort", new[] { "id,repair_type,work_type,description" },
            //    new[] { "1", "2", "1", "Ремонт и укрепление обочин" });
            //Database.Insert("rr_work_sort", new[] { "id,repair_type,work_type,description" },
            //    new[] { "2", "2", "1", "Ремонт откосов полотна и резервов" });
            //Database.Insert("rr_work_sort", new[] { "id,repair_type,work_type,description" },
            //    new[] { "3", "2", "2", "Восстановление слоя износа" });
            //Database.Insert("rr_work_sort", new[] { "id,repair_type,work_type,description" },
            //    new[] { "4", "1", "1", "Ремонт дождеприемных и смотровых колодцев" });
            //Database.Insert("rr_work_sort", new[] { "id,repair_type,work_type,description" },
            //    new[] { "5", "3", "3", "Устройство подпорных стенок,тоннелей, укрепительных сооружений" });

        }

        public override void Down()
        {
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_featureobject_fk");
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_performerFK");
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_ownerFK");
            Database.RemoveForeignKey("rr_roadrepair", "roadrepair_customerFK");
            Database.RemoveForeignKey("rr_address_roadrepair", "rr_address_roadrepair_to_roadrepair_fk");
            Database.RemoveForeignKey("rr_address_roadrepair", "rr_address_roadrepair_to_address_fk");
            Database.RemoveTable("rr_address_roadrepair");
            Database.RemoveTable("rr_roadrepair");
            Database.RemoveTable("rr_work_sort");
        }
    }
}
