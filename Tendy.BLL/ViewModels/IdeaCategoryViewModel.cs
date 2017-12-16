namespace Tendy.BLL.ViewModels
{
    public class IdeaCategoryViewModel
    {
        public int IdeaId { get; set; }
        public IdeaViewModel Idea { get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
