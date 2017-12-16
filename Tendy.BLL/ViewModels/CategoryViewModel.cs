using System.Collections.Generic;

namespace Tendy.BLL.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<IdeaCategoryViewModel> IdeaCategories { get; set; }
    }
}