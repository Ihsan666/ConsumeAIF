using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SafaItemDetails.Models;

namespace SafaItemDetails.Controllers
{
    public class ItemDetailsController : ApiController
    {
        // GET: api/ItemDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ItemDetails/5
        public Item Get(string id)
        {

            SafaItemDetailsService.ItemDetailsServiceClient _client = new SafaItemDetailsService.ItemDetailsServiceClient();
            SafaItemDetailsService.CallContext _context = new SafaItemDetailsService.CallContext();
            _context.Company = "safa";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "DOMAINAX.COM";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";
           
            JsonSerializerSettings _settings = new JsonSerializerSettings();

            string _data = _client.getItemDetails(_context, id);
            Item item = JsonConvert.DeserializeObject<Item>(_data, _settings);

            /*var result = new JsonResult {Data = JsonConvert.DeserializeObject(_data)};*/

            return item;
        }

        // POST: api/ItemDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItemDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItemDetails/5
        public void Delete(int id)
        {
        }
    }
}
