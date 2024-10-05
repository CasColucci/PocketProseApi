namespace PocketProseApi.Models
{
    public class Story
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
