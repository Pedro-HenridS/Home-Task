namespace domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Byte[] Icon { get; set; } = new Byte[0];

        public ICollection<Tasks> Task { get; set; } 
        public ICollection<Membering> Membering { get; set; }
    }
}
