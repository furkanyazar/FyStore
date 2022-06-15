using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Custom2022 : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public DateTime DateOf { get; set; } = DateTime.Now;
    }
}
