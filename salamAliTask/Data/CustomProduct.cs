namespace salamAliTask.Data
{
    public class CustomProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int CatId { get; set; }
        public List<CustomField> CustomFields { get; set; }
    }
}
