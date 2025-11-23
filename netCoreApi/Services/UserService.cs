using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using System.Reflection;
using netCoreApi.Repositories;
using netCoreApi.Models;
using netCoreApi.DTO;
namespace netCoreApi.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public UserService(UnitOfWork unitOfWork, IConfiguration configuration, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _env = env;
        }
        public async Task AddAsync(User entity)
        {
            await _unitOfWork.Users.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
        public async Task<IEnumerable<User>> TestSerilog()
        {
            throw new Exception("Test serilog");
        }
        public async Task AddRangeAsync(IEnumerable<User> entities)
        {
            await _unitOfWork.Users.AddRangeAsync(entities);
        }
        public async ValueTask<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
        
        public async Task RemoveAsync(User entity)
        {
            _unitOfWork.Users.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
