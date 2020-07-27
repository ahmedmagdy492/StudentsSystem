using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Task.Repository
{
    public interface INeighborhoodRepository
    {
        Task<IEnumerable<Neighborhood>> GetNeighborhoods();
        Task<IEnumerable<Neighborhood>> GetNeighborhoodsOfGovernrate(int govId);
    }
}
