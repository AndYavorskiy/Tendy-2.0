namespace Tendy.DAL.Entities
{
    public class IdeaImage
    {
        public int Id { get; set; }
        public int? IdeaId { get; set; }
        public virtual Idea Idea { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
