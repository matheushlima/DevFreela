using DevFreela.Core.Dtos;
using System.Threading.Tasks;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
