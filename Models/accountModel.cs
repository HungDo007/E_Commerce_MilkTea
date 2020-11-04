using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class accountModel
    {
        private milkTeaModel _context = null;
        public accountModel()
        {
            _context = new milkTeaModel();
        }
        public bool login(string username,string pass)
        {
            int res = _context.User_Accounts.Count(x => x.Username == username && x.Password == pass);
            if (res!=1)
            {
                return false;
            }
            return true;
        }
    }
}
