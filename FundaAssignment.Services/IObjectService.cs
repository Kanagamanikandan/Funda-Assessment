using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundaAssignment.Services
{
    public interface IObjectService
    {
       Task<IEnumerable<Entities.Makelaar>> GetTop10MakelaarsInAmsterdam(bool withTuin);
    }
}
