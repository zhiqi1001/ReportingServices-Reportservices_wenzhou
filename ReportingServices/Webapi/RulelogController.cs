using Model.RulelogS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportingServices
{
    public class RulelogController : ApiController
    {
        PetaPoco.Database db = new PetaPoco.Database("dbconn");

        // POST api/<controller>
        public BootRecord Post(EditBootRecord editbootRecord)
        {
            string tbname = "";
            if (editbootRecord.typeid== 1)
                tbname = "t_MachineStop_rd";
            else if(editbootRecord.typeid == 0)
            tbname = "t_AsyncSCR_rd";
            PetaPoco.Sql sql = new PetaPoco.Sql();
            sql.Select("*").From(tbname);
            sql.Where("id=@0", editbootRecord.id);
            BootRecord BootRecords = db.Fetch<BootRecord>(sql).FirstOrDefault();
            if (editbootRecord != null && BootRecords != null)
            {
                PetaPoco.Sql updateSql = new PetaPoco.Sql();
                BootRecords.description = editbootRecord.description;
                db.Update(tbname, "id", BootRecords);
            }
            return BootRecords;
        }
    }
}