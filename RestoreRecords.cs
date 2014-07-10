using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestoreRecords
{
    class RestoreRecords
    {
        static void Main(string[] args)
        {
            if(args.Length >= 2)
            {
                var crmConnection = new CrmConnection(args[0]);
                var executeRestore = new Restore(crmConnection, args[1]);
                executeRestore.Execute();
            }
            else
            {
                Console.WriteLine(String.Format("args.Length was {0} elements long. The programs take two argument, the location of the file for the crm connection, and the location of the file containing the Guids list (one per line)", args.Length));
                Console.ReadKey();
            }

        }
    }
}
