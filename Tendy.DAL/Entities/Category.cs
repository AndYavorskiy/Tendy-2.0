using System.Collections.Generic;

namespace Tendy.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IdeaCategory> IdeaCategories { get; set; }

        public Category()
        {
            IdeaCategories = new List<IdeaCategory>();
        }
    }
}