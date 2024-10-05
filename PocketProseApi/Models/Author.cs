namespace PocketProseApi.Models
{
    public class Author
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
