using Restaurant_Management_System.IService;

namespace Restaurant_Management_System.Service
{
    public class Offers
    {
        private readonly string _connectionString;

        public Offers(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

    }
}
