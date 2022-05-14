namespace BilgeAdam.Services
{
    public class ScopedService : BaseService
    {
    }

    public class TransientService : BaseService
    {
    }

    public class SingletonService : BaseService
    {
    }

    public class BaseService
    {
        public BaseService()
        {
            Created = DateTime.Now;
        }

        public int Count { get; set; }
        public DateTime Created { get; set; }
    }
}