namespace PocketProseApi.Models
{
    public class StoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
