namespace Tendy.DAL.Entities
{
   public class PublicationImage
    {
        public int Id { get; set; }

        public int? PublicationId { get; set; }
        public virtual Publication Publication { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
