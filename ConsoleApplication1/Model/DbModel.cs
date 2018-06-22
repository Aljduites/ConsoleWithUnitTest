using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class DbModel
    {
        private String _server, _database, _usrID, _passwd, _security;
        private Int32 _tout, _minCon, _maxCon;

        public String server { get { return _server; } set { _server = value; } }

        public String database { get { return _database; } set { _database = value; } }

        public String usrID { get { return _usrID; } set { _usrID = value; } }

        public String passwd { get { return _passwd; } set { _passwd = value; } }

        public String security { get { return _security; } set { _security = value; } }

        public Int32 tout { get { return _tout; } set { _tout = value; } }

        public Int32 maxCon { get { return _maxCon; } set { _maxCon = value; } }

        public Int32 minCon { get { return _minCon; } set { _minCon = value; } }
    }
}
