using Restaurant_Management_System.DTOs.AddressDTO;
using Restaurant_Management_System.Interfaces;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class AddressService : IAddress
    {
        private readonly RMSDbContext _context;
        public AddressService(RMSDbContext context)
        {
            _context = context;
        }
        public Task<string> AddAddressAsync(AddAddressDTO addAddressDTO)
        {
            try
            {
                if(addAddressDTO == null)
                {
                    throw new ArgumentNullException(nameof(addAddressDTO), "Address data cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(addAddressDTO.Province) || string.IsNullOrWhiteSpace(addAddressDTO.Region))
                {
                    throw new ArgumentException("Province and Region are required fields.");
                }
                if (addAddressDTO.UserId <= 0)
                {
                    throw new ArgumentException("Invalid User ID.");
                }

                _context.Addresses.Add(new Address
                {
                    Province = addAddressDTO.Province,
                    Region = addAddressDTO.Region,
                    AddressHint = addAddressDTO.AddressHint,
                    CreatedBy = addAddressDTO.CreatedBy,
                    CreationDate = DateTime.UtcNow,
                    IsActive = true,
                    UserId = addAddressDTO.UserId
                });
                _context.SaveChanges();
                return Task.FromResult("Address added successfully.");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Task.FromResult("An error occurred while adding the address.");
            }
        }
    }
}
