using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestoreRecords
{


    class RestoringEntitiesList
    {
        public List<Guid> AuditList { get; set; }

        public RestoringEntitiesList()
        {
            AuditList = new List<Guid>();
        }
    }
}
