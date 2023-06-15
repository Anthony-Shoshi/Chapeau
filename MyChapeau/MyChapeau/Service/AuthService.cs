using System.Security.Cryptography;
using System.Text;
using DAL;
using Model;

namespace Service
{
    public class AuthService
    {
        private AuthDao authDao;

        public AuthService()
        {
            authDao = new AuthDao();
        }

        public bool Authenticate(string username, string password) {
            return authDao.Authenticate(username, password);
        }

        public bool CheckUsernameExists(string username) { 
            return authDao.CheckUsernameExists(username);
        }

        public Employee GetEmployeeByUsername(string username) {
            return authDao.GetEmployeeByUsername(username);
        }

        public string GetHashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}