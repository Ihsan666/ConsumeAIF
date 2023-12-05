using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SafaItemDetails.Controllers
{
    public class ItemsListController : ApiController
    {
        // GET ALL: api/ItemsList/GetAllItems
        public JObject GetAllItems()
        {

            SafaItemDetailsService.ItemDetailsServiceClient _client = new SafaItemDetailsService.ItemDetailsServiceClient();
            SafaItemDetailsService.CallContext _context = new SafaItemDetailsService.CallContext();
            _context.Company = "safa";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "DOMAINAX.COM";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";

            JsonSerializerSettings _settings = new JsonSerializerSettings();

            string _data = _client.getAllItems(_context);
            JObject json = JObject.Parse(_data);
            return json;
        }

    }
}
