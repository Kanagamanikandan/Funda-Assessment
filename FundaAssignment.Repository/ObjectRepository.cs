using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace FundaAssignment.Repository
{
    public class ObjectRepository : IObjectRepository
    {
        private static HttpClient client = new HttpClient();
        private IEnumerable<Entities.Object> _objects;
        private IEnumerable<Entities.Object> _objectsWithTuin;
        private string _url;
        public ObjectRepository(string url)
        {
            _url = $"{url}/?type=koop";
        }
        public async Task<IEnumerable<Entities.Object>> GetObjects(string city)
        {
            if (_objects == null)
                _objects = await GetObjectFromRemote($"{_url}&zo=/{city}");
            return _objects;
        }

        public async Task<IEnumerable<Entities.Object>> GetObjectsWithTuin(string city)
        {
            if (_objectsWithTuin == null)
                _objectsWithTuin = await GetObjectFromRemote($"{_url}&zo=/{city}/tuin");
            return _objectsWithTuin;
        }

        private async Task<IEnumerable<Entities.Object>> GetObjectFromRemote(string url)
        {
            List<Entities.Object> objects = new List<Entities.Object>();
            ObjectHttpResponseParser objectHttpResponseParser;
            int currentPage = 0, totalPages = 0, pageSize = 25;

            do
            {
                try
                {
                    currentPage++;
                    var responseBody = await client.GetStreamAsync($"{url}/&page={currentPage}&pageSize={pageSize}");
                    objectHttpResponseParser = await JsonSerializer.DeserializeAsync<ObjectHttpResponseParser>(responseBody);
                    objects.AddRange(objectHttpResponseParser.Objects);
                    totalPages = objectHttpResponseParser.Paging.TotalPages;
                }
                catch (HttpRequestException e)
                {
                    await Task.Delay(10000); // wait for 10 secs and try again in case of exceeding request limit
                    currentPage--;
                }
            } while (currentPage < totalPages);

            return objects;
        }
    }
}
