namespace MovieApp.Models
{
    public class LikeModel
    {
        public string MovieId { get; set; }
        public string Title { get; set; }   
        public string Path { get; set; }
        public bool Liked { get; set; }
        public int NumOfLikes { get; set; }
    }
}
