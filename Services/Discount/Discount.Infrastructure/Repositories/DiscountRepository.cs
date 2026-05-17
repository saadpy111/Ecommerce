using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Infrastructure.Context;
using System.Data;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DapperContext _context;

        public DiscountRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = _context.CreateConnection();

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
                "SELECT * FROM Coupons WHERE ProductName = @ProductName",
                new
                {
                    ProductName = productName
                });

            if (coupon == null)
            {
                return new Coupon
                {
                    ProductName = "No Discount",
                    Description = "No Discount Available",
                    Amount = 0
                };
            }

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = _context.CreateConnection();

            var affected = await connection.ExecuteAsync(
                "INSERT INTO Coupons (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new
                {
                    coupon.ProductName,
                    coupon.Description,
                    coupon.Amount
                });

            return affected > 0;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = _context.CreateConnection();

            var affected = await connection.ExecuteAsync(
                @"UPDATE Coupons 
                  SET ProductName = @ProductName,
                      Description = @Description,
                      Amount = @Amount
                  WHERE Id = @Id",
                new
                {
                    coupon.Id,
                    coupon.ProductName,
                    coupon.Description,
                    coupon.Amount
                });

            return affected > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = _context.CreateConnection();

            var affected = await connection.ExecuteAsync(
                "DELETE FROM Coupons WHERE ProductName = @ProductName",
                new
                {
                    ProductName = productName
                });

            return affected > 0;
        }
    }
}