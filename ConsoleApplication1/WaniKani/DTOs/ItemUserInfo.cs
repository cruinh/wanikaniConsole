using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public class ItemUserInfo
    {
        public double? unlocked_date;
        public IEnumerable<string> user_synonyms;
        public string meaning_note;
        public string reading_note;
        public string srs;
        public int srs_numeric;
        public double? available_date;
        public Boolean burned;
        public double? burned_date;
        public double? reactivated_date;
        public int? meaning_correct;
        public int? meaning_incorrect;
        public int? meaning_max_streak;
        public int? meaning_current_streak;
        public int? reading_correct;
        public int? reading_incorrect;
        public int? reading_max_streak;
        public int? reading_current_streak;

        public DateTime? unlocked_date_native {
            get { return DateConverter.UnixTimeStampToDateTime(unlocked_date); }
        }

        public DateTime? available_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(available_date); }
        }

        public DateTime? burned_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(burned_date); }
        }

        public DateTime? reactivated_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(reactivated_date); }
        }
    }
}
