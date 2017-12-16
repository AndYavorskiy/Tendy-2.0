namespace Tendy.BLL.ViewModels
{
    public class PeopleGroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public IdeaViewModel IdeaAcceptedPeople { get; set; }

        public IdeaViewModel IdeaRequestedPeople { get; set; }
    }
}