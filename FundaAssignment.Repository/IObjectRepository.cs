using System;
using System.Collections.Generic;
using System.Text;
using FundaAssignment.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FundaAssignment.Repository
{
    public interface IObjectRepository
    {
        Task<IEnumerable<Entities.Object>> GetObjects();
        Task<IEnumerable<Entities.Object>> GetObjectsWithTuin();
    }
}
