using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHaveNoIdeaWhatImDoingAnyMore
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User AuthenticatedUser { get; private set; }

        public bool Login()
        {
            var manager = new DataManager();
            var user = manager.GetUser(Username, Password);
            if (user == null)
                return false;
            AuthenticatedUser = new User(user);
            return true;
        }
    }
}
