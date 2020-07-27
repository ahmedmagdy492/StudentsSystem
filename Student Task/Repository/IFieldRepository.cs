using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Student_Task.Repository
{
    public interface IFieldRepository
    {
        Task<IEnumerable<Field>> GetFields();
    }
}