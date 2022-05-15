using DeepLome.WebApi.Models;

namespace DTO.ApiModels
{
    public class UserDTO
    {
        public UserDTO()
        {
            Events = new HashSet<Event>();
        }

        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public string? UserPhoto { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}