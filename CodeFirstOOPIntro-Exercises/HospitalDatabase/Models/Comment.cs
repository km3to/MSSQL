namespace HospitalDatabase.Models
{
    using System;

    public class Comment
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public int AuthorId { get; set; }

        public virtual Visitation Visitation { get; set; }
    }
}
