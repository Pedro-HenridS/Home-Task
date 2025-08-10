namespace domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public ICollection<User_Task> User_Task { get; set; }
        public ICollection<Membering> Membering { get; set; }
        public ICollection<Friends> FriendsAsUser1 { get; set; }
        public ICollection<Friends> FriendsAsUser2 { get; set; }
    }
}
