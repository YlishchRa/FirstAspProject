using System.Collections;
using WebTest.Models;
namespace DB
{
    public static class Database
    {
        public static List<User> users = new List<User>();


        public static void Constructor()
        {
            // for example you can take data from DB
        }
        public static bool UserInDB(string email)
        {
            foreach(User us in users)
            {
                if(us.Email == email) 
                    return true;
            }
            return false;
        }

    }
}
