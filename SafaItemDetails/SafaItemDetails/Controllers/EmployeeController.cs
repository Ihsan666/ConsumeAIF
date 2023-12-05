using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SafaItemDetails.Models;

namespace SafaItemDetails.Controllers
{
    public class EmployeeController : ApiController
    {


        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public string Post([FromBody]Employee value)
        {
            SafaItemDetailsService.ItemDetailsServiceClient _client = new SafaItemDetailsService.ItemDetailsServiceClient();
            SafaItemDetailsService.CallContext _context = new SafaItemDetailsService.CallContext();
            _context.Company = "safa";

            _client.ClientCredentials.Windows.ClientCredential.Domain = "DOMAINAX.COM";
            _client.ClientCredentials.Windows.ClientCredential.UserName = "880151";
            _client.ClientCredentials.Windows.ClientCredential.Password = "880151";
 
            string _data = _client.CreateEmployee(_context, value.EmpID, value.FirstName, value.MiddleName, value.LastName, value.dbo+"", value.EmpStartDate+"", value.isRetail);
           // string _data = _client.CreateEmployee(_context, "880151", "Abdullah", "ahmed", "khan", dob, joining,true);
            return _data;

        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
