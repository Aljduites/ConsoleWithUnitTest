using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Helper
{
    public class MyCon
    {
        #region PrivateDeclaration
        private DbCon _db;
        private String server = string.Empty;
        private String database = string.Empty;
        private String usrID = string.Empty;
        private String passwd = string.Empty;
        private String security = string.Empty;
        private Int32 tout = 0;
        private String ConPath;
        private List<DbModel> models = new List<DbModel>();
        #endregion

        #region Connection
        internal MyCon()
        {
            ConPath = String.Format("{0}",@"C:\\testConfig\\testing.ini");
        }

        protected internal void ConnectDB()
        {
            var ini = new IniFile(ConPath);
            models.Add(new DbModel() { 
                server = ini.IniReadValue("OTHER SERVER","SERVER"),
                database = ini.IniReadValue("OTHER SERVER", "DBNAME"),
                usrID = ini.IniReadValue("OTHER SERVER", "USERNAME"),
                passwd = ini.IniReadValue("OTHER SERVER", "PASSWORD"),
                tout = Convert.ToInt32(ini.IniReadValue("OTHER SERVER", "Tout")),
                security = ini.IniReadValue("OTHER SERVER", "Pool"),
                maxCon = Convert.ToInt32(ini.IniReadValue("OTHER SERVER", "MaxCon")),
                minCon = Convert.ToInt32(ini.IniReadValue("OTHER SERVER", "MinCon"))
            });            
            this.db = new DbCon(models);
        }

        public DbCon db { get { return _db; } set { _db = value; } }

        #endregion
    }
}
