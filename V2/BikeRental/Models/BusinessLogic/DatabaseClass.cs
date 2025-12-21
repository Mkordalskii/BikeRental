namespace BikeRental.Models.BusinessLogic
{
    public class DatabaseClass
    {
        protected BikeRentalDbEntities db;
        public DatabaseClass(BikeRentalDbEntities db)
        {
            this.db = db;
        }
    }
}
