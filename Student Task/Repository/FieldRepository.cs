using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Student_Task.Repository
{
    public class FieldRepository : IFieldRepository
    {
        private readonly SchoolModel _context;

        public FieldRepository(SchoolModel context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Field>> GetFields()
        {
            return await _context.Fields.ToListAsync();
        }
    }
}