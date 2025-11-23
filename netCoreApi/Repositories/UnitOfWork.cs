
using Microsoft.EntityFrameworkCore.Storage;
using netCoreApi.Models;


namespace netCoreApi.Repositories
{
    public class UnitOfWork
    {
        private readonly DotNetApiContext _context;

        private UserRepository _userRepository;
        public UnitOfWork(DotNetApiContext context)
        {
            _context = context;
        }
        public UserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
