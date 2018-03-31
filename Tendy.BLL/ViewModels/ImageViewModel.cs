namespace Tendy.BLL.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }

        public string SorceUrl { get; set; }

        public bool? IsMain { get; set; }

        public IdeaImageViewModel IdeaImage { get; set; }
    }
}