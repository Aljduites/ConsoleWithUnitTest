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

                String constring = String.Format("server = {0}; database = {1}; uid = {2}; password = {3}; pooling = {4}; min pool size= {5}; " + 
                    "max pool size= {6};connection lifetime=0; connection timeout = {7};Allow Zero Datetime=true; Convert Zero DateTime=true;SslMode=none",
                    model[0].server, model[0].database, model[0].usrID, model[0].passwd, sec, model[0].minCon, model[0].maxCon, model[0].tout);

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
                String constring = String.Format("server = {0}; database = {1}; uid = {2}; password = {3}; pooling = {4}; min pool size= {5}; " +
                "max pool size= {6};connection lifetime=0; connection timeout = {7};Allow Zero Datetime=true; Convert Zero DateTime=true;SslMode=none",
                server, db, uID, pwd, sec, minCon, maxCon, tout);
 
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
