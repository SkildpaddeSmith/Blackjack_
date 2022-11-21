using Blackjack.Models;
using Blackjack.SQL;

namespace Blackjack.Services
{
    public class SecurityServices
    {
        SQL_Connection SQL = new SQL_Connection();
        public bool IsValid(LoginModel user)
        {
            return SQL.FindUserByNameAndPassword(user);
        }

        public bool UniqueUser(LoginModel user)
        {
            return SQL.AddUserToDatabase(user);
        }

        public bool PasswordMatch(LoginModel user)
        {
            return SQL.CheckPasswords(user);
        }
    }
}
