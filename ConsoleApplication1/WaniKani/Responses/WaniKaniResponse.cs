using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public interface IWaniKaniResponse
    {
        HttpResponseMessage httpResponse { get; set; }
        Boolean success();
    }
}
