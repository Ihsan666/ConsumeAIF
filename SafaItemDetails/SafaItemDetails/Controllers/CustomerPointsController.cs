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
    public class CustomerPointsController : ApiController
    {
        // GET: api/CustomerPoints
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CustomerPoints/5
        public CustomerPoints Get(string id)
        {
            SafaItemDetailsService.ItemDetailsServiceClient _client = new SafaItemDetailsService.ItemDetailsServiceClient();
            SafaItemDetailsService.CallContext _context = new SafaItemDetailsService.CallContext();
            _context.Company = "safa";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "DOMAINAX.COM";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";

            JsonSerializerSettings _settings = new JsonSerializerSettings();

            string _data = _client.getCustomerPoints(_context, id);
            CustomerPoints item = JsonConvert.DeserializeObject<CustomerPoints>(_data, _settings);

            /*var result = new JsonResult {Data = JsonConvert.DeserializeObject(_data)};*/

            return item;
        }

        // POST: api/CustomerPoints
        public CustomerPoints Post([FromBody]CustomerPoints value)
        {
            string _data="";

            SafaItemDetailsService.ItemDetailsServiceClient _client = new SafaItemDetailsService.ItemDetailsServiceClient();
            SafaItemDetailsService.CallContext _context = new SafaItemDetailsService.CallContext();
            _context.Company = "safa";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "DOMAINAX.COM";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";
            JsonSerializerSettings _settings = new JsonSerializerSettings();
            
            switch (value.type)
            { 
                case "earn":
                case "redeem":
                    _data = _client.earnOrRedeemPoints(_context, value.CustomerId, value.type, value.Points.ToString(),value.WebOrderId);
                    break;
                case "get":
                    _data = _client.getCustomerPoints(_context,value.CustomerId);
                    break;

            }
            
            CustomerPoints item = JsonConvert.DeserializeObject<CustomerPoints>(_data, _settings);
            return item;
        }

        // PUT: api/CustomerPoints/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerPoints/5
        public void Delete(int id)
        {
        }
    }
}
