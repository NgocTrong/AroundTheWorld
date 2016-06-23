using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.Dao
{
    public class TopicDao
    {
        private TravelDbContext db;
        public TopicDao()
        {
            db = new TravelDbContext();
        }

        //list Topic
        public List<Topic> ListAll()
        {
            return db.Topics.ToList();
        }
    }
}
