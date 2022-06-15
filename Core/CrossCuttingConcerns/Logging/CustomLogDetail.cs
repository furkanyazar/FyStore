using Core.Entities.Abstract;

namespace Core.CrossCuttingConcerns.Logging
{
    public class CustomLogDetail
    {
        public IEntity Entity { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
    }
}
