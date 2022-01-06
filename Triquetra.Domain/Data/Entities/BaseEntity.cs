namespace Triquetra.Domain.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
