using Microsoft.IdentityModel.Tokens;
using Restaurant_Management_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant_Management_System.Helper
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(User input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes("LongSecrectStringForModulekodestartppopopopsdfjnshbvhueFGDKJSFBYJDSAGVYKDSGKFUYDGASYGFskc vhHJVCBYRVSKEGHASVBCL");

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", input.Email),
                       new Claim("UserId", input.UserId.ToString() ),
                    new Claim("Activation", input.IsActive + ""),
                    //new Claim("Key", input.Key  ),
                    //new Claim("IV", input.Iv )
                }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                  , SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);


        }



            public static bool IsValidToken(string tokenString) //decode 

        { 
            String toke = "Bearer" + tokenString;
            var jwtEncodedString = toke.Substring(7);
            //for fetch
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            if (token.ValidTo > DateTime.UtcNow)
            {
                //valid 
                //read clims
                int userId = int.Parse((token.Claims.First(c => c.Type == "UserId").Value.ToString()));
           
                return true;
            }
            return false;  

          ;


        }
    }
}
