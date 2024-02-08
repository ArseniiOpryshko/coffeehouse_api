using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Museum.Data.ObjsForAuth
{
    public class AuthOptions
    {
        const string KEY = "phahcoffeekey1232134231";
        public const int LIFETIME = 24;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
