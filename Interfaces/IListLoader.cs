using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestoreRecords.Interfaces
{
    interface IListLoader
    {
        List<Guid> LoadGuidList();
    }
}
