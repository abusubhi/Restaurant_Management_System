using Restaurant_Management_System.DTOs.PaymentCardDTO;
using Restaurant_Management_System.Interfaces;
using Restaurant_Management_System.Models;
using System.Text.RegularExpressions;

namespace Restaurant_Management_System.Service
{
    public class PaymentCardService : IPaymentCard
    {
        private readonly RMSDbContext _context;
        public PaymentCardService(RMSDbContext context)
        {
            _context = context;
        }
        public Task<string> AddPaymentCard(AddPaymentCardDTO addPaymentCardDTO)
        {
            try
            {
                if (addPaymentCardDTO == null)
                    return Task.FromResult("Payment card details cannot be null");

                //if (string.IsNullOrWhiteSpace(addPaymentCardDTO.CardNumber) ||
                //    !IsValidCardNumber(addPaymentCardDTO.CardNumber))
                    //return Task.FromResult("Invalid card number");

                if (string.IsNullOrWhiteSpace(addPaymentCardDTO.CardHolderName))
                    return Task.FromResult("Card holder name is required");


                if (string.IsNullOrWhiteSpace(addPaymentCardDTO.Cvv) ||
                    !Regex.IsMatch(addPaymentCardDTO.Cvv, @"^\d{3,4}$"))
                    return Task.FromResult("Invalid CVV");

                if (string.IsNullOrWhiteSpace(addPaymentCardDTO.CardType))
                    return Task.FromResult("Card type is required");

                if (addPaymentCardDTO.UserId <= 0)
                    return Task.FromResult("Invalid User ID");

                var paymentCard = new CardPayment
                {
                    CardNumber = addPaymentCardDTO.CardNumber,
                    CardHolderName = addPaymentCardDTO.CardHolderName,
                    ExpiryDate = addPaymentCardDTO.ExpiryDate,
                    Cvv = addPaymentCardDTO.Cvv,
                    CardType = addPaymentCardDTO.CardType,
                    UserId = addPaymentCardDTO.UserId
                };

                _context.CardPayments.Add(paymentCard);
                _context.SaveChanges();

                return Task.FromResult("Payment card added successfully");
            }
            catch (Exception ex)
            {
                return Task.FromResult($"An error occurred while adding the payment card: {ex.Message}");
            }
        }

        // Luhn Algorithm for credit card validation
        //private bool IsValidCardNumber(string cardNumber)
        //{
        //    cardNumber = cardNumber.Replace(" ", "");
        //    int sum = 0;
        //    bool alternate = false;

        //    for (int i = cardNumber.Length - 1; i >= 0; i--)
        //    {
        //        if (!char.IsDigit(cardNumber[i]))
        //            return false;

        //        int n = int.Parse(cardNumber[i].ToString());

        //        if (alternate)
        //        {
        //            n *= 2;
        //            if (n > 9)
        //                n -= 9;
        //        }

        //        sum += n;
        //        alternate = !alternate;
        //    }

        //    return (sum % 10 == 0);
        //}

    }
}
