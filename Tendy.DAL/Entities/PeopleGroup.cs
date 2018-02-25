namespace Tendy.DAL.Entities
{
	public class PeopleGroup 
	{
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual Idea IdeaAcceptedPeople { get; set; }
        public virtual Idea IdeaRequestedPeople { get; set; }
    }
}