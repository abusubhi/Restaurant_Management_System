using Restaurant_Management_System.IService;

namespace Restaurant_Management_System.Service
{
    public class OffersService
    {
        private readonly string _connectionString;

        public OffersService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

    }
}
