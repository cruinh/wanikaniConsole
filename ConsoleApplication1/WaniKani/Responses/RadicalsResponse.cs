using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public class RadicalsResponse : WaniKaniResponse
    {
        public HttpResponseMessage httpResponse { get; set; }
        public Boolean success()
        {
            if (user_information != null && requested_information != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserInfo user_information { get; set; }
        public IEnumerable<Radical> requested_information { get; set; }
    }
}
