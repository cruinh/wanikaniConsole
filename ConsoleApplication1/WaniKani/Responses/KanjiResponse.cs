using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WaniKani
{
    public class KanjiResponse : WaniKaniResponse
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
        public IEnumerable<Kanji> requested_information { get; set; }
    }
}
