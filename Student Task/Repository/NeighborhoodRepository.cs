using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Student_Task.Repository
{
    public class NeighborhoodRepository : INeighborhoodRepository
    {
        private readonly SchoolModel _context;

        public NeighborhoodRepository(SchoolModel context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Neighborhood>> GetNeighborhoods()
        {
            return await _context.Neighborhoods.ToListAsync();
        }

        public async Task<IEnumerable<Neighborhood>> GetNeighborhoodsOfGovernrate(int govId)
        {
            return await _context.Neighborhoods.Where(n => n.GovernorateId == govId).ToListAsync();
        }
    }
}