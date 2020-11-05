using milkTeaModelsss.frameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milkTeaModelsss
{
    public class accountModel
    {
        private milkTeaModels _context = null;
        public accountModel()
        {
            _context = new milkTeaModels();
        }

        public bool login(string username, string pass)
        {
            int res = _context.User_Accounts.Count(x => x.Username == username && x.Password == pass);
            if (res != 1)
                return false;
            return true;
        }

        public bool register(User_Accounts accounts)
        {
            try
            {
                _context.User_Accounts.Add(accounts);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
