namespace DeepLome.Models.DatabaseModles
{
    public partial class UsersAtEvent
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? UserId { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
