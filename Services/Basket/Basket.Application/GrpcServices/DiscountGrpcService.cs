using Discount.Grpc.Protos;

namespace Basket.Application.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _disocuntGrpcClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient disocuntGrpcClient)
        {
            _disocuntGrpcClient = disocuntGrpcClient;
        }
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest() {  ProductName = productName};
            var discount = await _disocuntGrpcClient.GetDiscountAsync(discountRequest);
            return discount;
        }
    }
}
