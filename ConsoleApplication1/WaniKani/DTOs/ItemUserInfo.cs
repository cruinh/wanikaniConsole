using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public class ItemUserInfo
    {
        public UInt64 unlocked_date;
        public IEnumerable<string> user_synonyms;
        public string meaning_note;
        public string reading_note;
        public string srs;
        public int srs_numeric;
        public UInt64 available_date;
        public Boolean burned;
        public UInt64 burned_date;
        public UInt64 reactivated_date;
        public Nullable<int> meaning_correct;
        public Nullable<int> meaning_incorrect;
        public Nullable<int> meaning_max_streak;
        public Nullable<int> meaning_current_streak;
        public Nullable<int> reading_correct;
        public Nullable<int> reading_incorrect;
        public Nullable<int> reading_max_streak;
        public Nullable<int> reading_current_streak;

        public DateTime unlocked_date_native {
            get { return DateConverter.UnixTimeStampToDateTime(unlocked_date); }
        }

        public DateTime available_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(available_date); }
        }

        public DateTime burned_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(burned_date); }
        }

        public DateTime reactivated_date_native
        {
            get { return DateConverter.UnixTimeStampToDateTime(reactivated_date); }
        }
    }
}
