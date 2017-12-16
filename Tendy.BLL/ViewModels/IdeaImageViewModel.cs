namespace Tendy.BLL.ViewModels
{
    public class IdeaImageViewModel
    {
        public int Id { get; set; }
        public int? IdeaId { get; set; }
        public IdeaViewModel Idea { get; set; }

        public int? ImageId { get; set; }
        public ImageViewModel Image { get; set; }
    }
}
