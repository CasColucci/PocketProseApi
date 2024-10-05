namespace PocketProseApi.Models
{
    public class StoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public Genre Genre { get; set; }
    }
}
