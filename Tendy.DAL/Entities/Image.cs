namespace Tendy.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string SorceUrl { get; set; }
        public bool? IsMain { get; set; }

        public virtual IdeaImage IdeaImage { get; set; }
        public virtual PublicationImage PublicationImage { get; set; }
    }
}