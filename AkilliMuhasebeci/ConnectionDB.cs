using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkilliMuhasebeci
{
    class ConnectionDB
    {
        public String GetConnection()
        {
            String con = ("server=(localdb)\\MSSQLLocalDB;Initial Catalog=AkilliMuhasebeci;Integrated Security=True");
            return con;
        }

        public static string PERMISSION;

    }
}
