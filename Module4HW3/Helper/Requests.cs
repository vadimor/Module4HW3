using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Entity;

namespace Module4HW3.Helper
{
    public class Requests
    {
        private readonly ApplicationDbContext _context;
        private readonly TransactionHelper _transaction;

        public Requests(ApplicationDbContext context, TransactionHelper transactionHelper)
        {
            _context = context;
            _transaction = transactionHelper;
        }

        public async Task FirstRequest()
        {
            var req = await _context.Employee
                .Include(i => i.Title)
                .Include(i => i.Office).ToListAsync();
        }

        public async Task SecondRequest()
        {
                var req = await _context.Employee
                .Select(e => EF.Functions.DateDiffDay(e.HiredDate, DateTime.UtcNow))
                .ToListAsync();
        }

        public async Task ThreeRequest()
        {
            await _transaction.TransactionShellAsync(async () =>
            {
                var first = await _context.Employee.FirstAsync();
                first.FirstName = "VIKTOR";
                await _context.SaveChangesAsync();
                var second = await _context.Employee.Skip(1).FirstAsync();
                second.FirstName = "NEVIKTOR";
                await _context.SaveChangesAsync();
            });
        }

        public async Task FourRequest()
        {
            await _transaction.TransactionShellAsync(async () =>
            {
                await _context.Title.AddAsync(new TitleEntity { TitleId = 3, Name = "Vor" });
                await _context.SaveChangesAsync();
                await _context.Project.AddAsync(new ProjectEntity { ProjectId = 1, Name = "Diya", Budget = 2000, StartedDate = new DateTime(2019, 1, 1) });
                await _context.SaveChangesAsync();
                await _context.Employee.AddAsync(new EmployeeEntity { EmployeeId = 5, FirstName = "Dima", SecondName = "Menshakov", OfficeId = 1, TitleId = 3, HiredDate = new DateTime(2017, 2, 22) });
                await _context.SaveChangesAsync();
                await _context.EmployeeProject.AddAsync(new EmployeeProjectEntity { EmployeeProjectId = 1, EmployeeId = 5, ProjectId = 1, Rate = 29, StartedDate = new DateTime(2019, 12, 1) });
                await _context.SaveChangesAsync();
            });
        }

        public async Task FiveRequest()
        {
            await _transaction.TransactionShellAsync(async () =>
            {
                var last = await _context.Employee.OrderBy(e => e.EmployeeId).LastAsync();
                _context.Employee.Remove(last);
                await _context.SaveChangesAsync();
            });
        }

        public async Task SixRequest()
        {
            var req = await _context.Employee
           .Include(t => t.Title)
           .GroupBy(g => g.Title.Name)
           .Select(s => s.Key)
           .Where(w => !EF.Functions.Like(w, "%a%")).ToListAsync();
        }
    }
}
