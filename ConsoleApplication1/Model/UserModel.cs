using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class UserModel
    {
        private Int32 _id, _Age;
        private String _Name,_Address;

        public Int32 id { get { return _id; } set { _id = value; } }

        public String Name { get { return _Name; } set { _Name = value; } }

        public Int32 Age { get { return _Age; } set { _Age = value; } }

        public String Address { get { return _Address; } set { _Address = value; } }
    }
}
