using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Student_Task.Repository
{
    public class GovernorateRepository : IGovernorateRepository
    {
        private readonly SchoolModel _context;

        public GovernorateRepository(SchoolModel context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Governorate>> GetGovernorates()
        {
            return await _context.Governorates.ToListAsync();
        }
    }
}