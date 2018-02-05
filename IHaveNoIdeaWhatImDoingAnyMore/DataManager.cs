using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHaveNoIdeaWhatImDoingAnyMore
{
    class DataManager
    {
        readonly eDiaryDBModel _ctx;
        public DataManager()
        {
            _ctx = new eDiaryDBModel();
            if (!_ctx.User.Any(x => x.username == "admin"))
            {
                _ctx.User.Add(new User
                {
                    user_id = 0,
                    username = "admin",
                    password = "admin",
                    user_access_rank = 1

                });
                _ctx.SaveChanges();
            }
        }
        public User GetUser (string username, string password)
        {
            try
            {
                return _ctx.User.FirstOrDefault(x => x.username == username && x.password == password);
            }
            catch (InvalidOperationException)
            {

                return null;
            }
        }
    }
}
