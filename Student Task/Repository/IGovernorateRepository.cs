using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Task.Repository
{
    public interface IGovernorateRepository
    {
        Task<IEnumerable<Governorate>> GetGovernorates();
    }
}
