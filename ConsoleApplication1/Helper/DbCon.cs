using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.Helper
{
    public class DbCon
    {
        #region Declaration
        private MySqlConnection connection;
        private Boolean sec = false;
        private log4net.ILog _logs = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Connection
        internal DbCon(List<DbModel> model)
        {
            initialize(model);
        }
        internal DbCon(String server, String db, String uID, String pwd, String security, Int32 tout, Int32 maxCon, Int32 minCon)
        {
            initialize(server, db, uID, pwd, security, tout, minCon, maxCon);
        }

        private void initialize(List<DbModel> model)
        {
            try
            {
                if(model[0].security.Equals(String.Format("{0}","1")))
                {
                    sec = true;
                }

                String constring = String.Format("{0}", "server = " + model[0].server + "; database = " + model[0].database + "; uid = "+ model[0].usrID +
                    "; password = " + model[0].passwd + "; pooling = " + sec + "; min pool size= " + model[0].minCon + "; max pool size=" + model[0].maxCon +
                    ";connection lifetime=0; connection timeout = " + model[0].tout + ";Allow Zero Datetime=true; Convert Zero DateTime=true;SslMode=none");

                connection = new MySqlConnection(constring);
            }
            catch (Exception ex)
            {
                _logs.Fatal(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        private void initialize(String server, String db, String uID, String pwd, String security, Int32 tout, Int32 minCon, Int32 maxCon)
        {
            try
            {
                if(security.Equals("1"))
                {
                    sec = true;
                }
                String constring = String.Format("{0}", "server = " + server + "; database = " + db + "; uid = " + uID +
                "; password = " + pwd + "; pooling = " + sec + "; min pool size= " + minCon + "; max pool size=" + maxCon +
                ";connection lifetime=0; connection timeout = " + tout + ";Allow Zero Datetime=true; Convert Zero DateTime=true;SslMode=none");

                connection = new MySqlConnection(constring);
            }
            catch (Exception ex)
            {
                _logs.Fatal(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public MySqlConnection connect()
        {
            return connection;
        }
        #endregion
    }
}
