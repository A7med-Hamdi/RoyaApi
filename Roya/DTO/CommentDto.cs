namespace Roya.DTO
{
    public class CommentDto
    {
           
        public DateTime DateTime { get; set; }
        public string text { get; set; }

        public string UserName { get; set; }
        public string UserImage { get; set; }

        public int ProductId { get; set; }

    }
}
