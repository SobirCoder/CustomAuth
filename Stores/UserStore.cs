using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CustomAuth 
{
    public class UserStore : IUserStore<User>
    {
        private SqlConnection con { get; set; }
        private string UsersTableName="CustomAuthUsers";
        private PasswordHasher<User> passwordHasher=new PasswordHasher<User>();
        public UserStore(IConfiguration config):base()
        {
            con=new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
           cancellationToken.ThrowIfCancellationRequested();
            using (con)
            {
                string insert_query=$"insert into {UsersTableName} (username, password) values (@username,@password)";
                
                var res=con.Execute(insert_query,new {username=user.UserName, 
                            password=passwordHasher.HashPassword(user,user.Password)});
                if(res > 0) 
                {
                    return IdentityResult.Success;
                }
                return IdentityResult.Failed(new IdentityError(Description=$"Coudn't insert {user.UserName}"));
            }
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}