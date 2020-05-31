using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FundaAssignment.Repository;
using System.Linq;
using FundaAssignment.Entities;

namespace FundaAssignment.Services
{
    public class ObjectService : IObjectService
    {
        private IObjectRepository _objectRepository;
        public ObjectService(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }
        public async Task<IEnumerable<Entities.Makelaar>> GetTop10MakelaarsInAmsterdam(bool withTuin = false)
        {
            var objects = withTuin ? await _objectRepository.GetObjectsWithTuin() : await _objectRepository.GetObjects();
            return objects.GroupBy(o => new { o.MakelaarId, o.MakelaarNaam })
                 .Select(group =>
                 new Makelaar
                 {
                     MakelaarId = group.Key.MakelaarId,
                     MakelaarName = group.Key.MakelaarNaam,
                     NoOfObjectListed = group.Count()
                 })
                 .OrderByDescending(m => m.NoOfObjectListed).Take(10);
        }

    }
}
