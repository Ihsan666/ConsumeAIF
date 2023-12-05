using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafaItemDetails.Models;

namespace SafaItemDetails.Controllers
{
    public class NTController : ApiController
    {

        // GET ALL: api/NT/GetJournalIds
        public JObject GetJournalIds()
        {
            
            NTServiceRef.ItemDetailsServiceClient _client = new NTServiceRef.ItemDetailsServiceClient();
            NTServiceRef.CallContext _context = new NTServiceRef.CallContext();
            _context.Company = "AQD";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "natural.com";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";

            JsonSerializerSettings _settings = new JsonSerializerSettings();

            string _data = _client.getOpenTagCountJournals(_context);
            JObject json = JObject.Parse(_data);
            return json;
        }
        // GET ALL: api/GetBatchId/GetBatchId
        [HttpGet]
        public JObject GetBatchId(string itemid)
        {

            NTServiceRef.ItemDetailsServiceClient _client = new NTServiceRef.ItemDetailsServiceClient();
            NTServiceRef.CallContext _context = new NTServiceRef.CallContext();
            _context.Company = "AQD";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "natural.com";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";

            JsonSerializerSettings _settings = new JsonSerializerSettings();

            string _data = _client.getItemBatches(_context, itemid);
            JObject json = JObject.Parse(_data);
            return json;
        }
        // GET ALL: api/NT/GetItemId/?barcode=xxx
        [HttpGet]
        public JObject GetItemId(string barcode, string journalId)
        {

            NTServiceRef.ItemDetailsServiceClient _client = new NTServiceRef.ItemDetailsServiceClient();
            NTServiceRef.CallContext _context = new NTServiceRef.CallContext();
            _context.Company = "AQD";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "natural.com";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";

            JsonSerializerSettings _settings = new JsonSerializerSettings();

            string _data = _client.geDetailsFromBarcode(_context, barcode, journalId);
            JObject json = JObject.Parse(_data);
            return json;
        }
        //api/NT/
        public string Post([FromBody]TagCountLine value)
        {
            string _data = "";

            NTServiceRef.ItemDetailsServiceClient _client = new NTServiceRef.ItemDetailsServiceClient();
            NTServiceRef.CallContext _context = new NTServiceRef.CallContext();
            _context.Company = "AQD";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "natural.com";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";

            _data = _client.CreateTagCountLine(_context, value.JournalId, value.ItemId, value.Barcode, (decimal)value.Qty, value.BatchId);

            return _data;
        }

    }
}