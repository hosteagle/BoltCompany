using BoltCompany.Domain.Entities.Base;

namespace BoltCompany.Domain.Entities
{
    public class ExtraPage : Entity
    {
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public string Path { get; set; }
    }
}