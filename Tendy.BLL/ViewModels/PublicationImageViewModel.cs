namespace Tendy.BLL.ViewModels
{
   public class PublicationImageViewModel
    {
        public int Id { get; set; }

        public int? PublicationId { get; set; }

        public PublicationViewModel Publication { get; set; }

        public int? ImageId { get; set; }

        public ImageViewModel Image { get; set; }
    }
}
