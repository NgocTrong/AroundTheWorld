using Models.EF;

namespace Models.Dao
{
    public class ContactDao
    {
        TravelDbContext db= null;
        public ContactDao()
        {
            db = new TravelDbContext();
        }

        public long Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return entity.ContactId;
        }


    }
}
