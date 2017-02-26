using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public class UserInfo
    {
        public string username { get; set; }
        public string gravatar { get; set; }
        public int level { get; set; }
        public string title { get; set; }
        public string about { get; set; }
        public string website { get; set; }
        public string twitter { get; set; }
        public int topics_count { get; set; }
        public int posts_count{ get; set; }
        public double? creation_date { get; set; }
        public double? vacation_date { get; set; }

        public DateTime? creation_date_native
        {
            get {  return DateConverter.UnixTimeStampToDateTime(creation_date);  }
        }

        public DateTime? vacation_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(vacation_date); }
        }
    }
}
