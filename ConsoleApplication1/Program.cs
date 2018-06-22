using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ConsoleApplication1.Helper;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    public class Program
    {
        

        public static void Connected(){
            MyCon _con = new MyCon();
            _con.ConnectDB();
            using(MySql.Data.MySqlClient.MySqlConnection connect = _con.db.connect())
            {
                connect.Open();
                string sql = String.Format("{0}", "SELECT * FROM Customer");
                List<UserModel> tested = connect.Query<UserModel>(sql).ToList();
                connect.Close();
                Console.WriteLine(tested);
            }

        }
        public static void Connected2()
        {
            MyCon _con = new MyCon();
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;
            _con.ConnectDB();
            using(MySql.Data.MySqlClient.MySqlConnection connect = _con.db.connect()){
                connect.Open();
                string sql = String.Format("{0}","SELECT * FROM Customer");
                MySql.Data.MySqlClient.MySqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 600;
                rdr = cmd.ExecuteReader();
                if(rdr.HasRows)
                {
                    Console.WriteLine(rdr);
                }

                connect.Close();
            }
        }

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
