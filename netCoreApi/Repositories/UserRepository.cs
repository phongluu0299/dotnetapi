using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using netCoreApi.Models;

namespace netCoreApi.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        private DotNetApiContext DotNetApiContext
        {
            get { return Context as DotNetApiContext; }
        }
        public async ValueTask<User?> GetByUserNameAsync(string userName)
        {
            try
            {
                return await DotNetApiContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
