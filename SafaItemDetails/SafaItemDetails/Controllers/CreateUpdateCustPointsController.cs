using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SafaItemDetails.Models;
using Newtonsoft.Json;

namespace SafaItemDetails.Controllers
{
    public class CreateUpdateCustPointsController : ApiController
    {
        // GET: api/CreateUpdateCustPoints
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CreateUpdateCustPoints/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CreateUpdateCustPoints
        public CustomerPoints Post([FromBody]CustomerPoints value)
        {
            SafaItemDetailsService.ItemDetailsServiceClient _client = new SafaItemDetailsService.ItemDetailsServiceClient();
            SafaItemDetailsService.CallContext _context = new SafaItemDetailsService.CallContext();
            _context.Company = "safa";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "DOMAINAX.COM";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";
            JsonSerializerSettings _settings = new JsonSerializerSettings();
            string _data = _client.earnOrRedeemPoints(_context, value.CustomerId, value.type, value.Points.ToString(),value.WebOrderId);
            CustomerPoints item = JsonConvert.DeserializeObject<CustomerPoints>(_data, _settings);
            return item;
        }

        // PUT: api/CreateUpdateCustPoints/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CreateUpdateCustPoints/5
        public void Delete(int id)
        {
        }
    }
}
