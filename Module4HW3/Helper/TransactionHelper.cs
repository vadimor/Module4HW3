using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module4HW3.Helper
{
    public class TransactionHelper
    {
        private readonly DbContext _context;

        public TransactionHelper(DbContext context)
        {
            _context = context;
        }

        public async Task TransactionShellAsync(Func<Task> func)
        {
             await using (var transaction = await _context.Database.BeginTransactionAsync())
             {
                try
                {
                    await func();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
