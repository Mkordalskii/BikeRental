namespace BikeRental.Helper
{
    public class ForeignKeyIdAndNameRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ForeignKeyIdAndNameRecord()
        {

        }

        public ForeignKeyIdAndNameRecord(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
