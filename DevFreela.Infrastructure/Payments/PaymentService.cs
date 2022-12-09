using DevFreela.Core.Dtos;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";
        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            //CONSUMINDO OUTRA API VIA HTTP
            //var url = $"{_paymentBaseUrl}/api/payments";
            //var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            //var paymentInfoContent = new StringContent(
            //    paymentInfoJson,
            //    Encoding.UTF8,
            //    "application/json");

            //var httpClient = _httpClientFactory.CreateClient("Payments");

            //var response = await httpClient.PostAsync(url, paymentInfoContent);

            //return response.IsSuccessStatusCode;

            //UTILIZANDO RabbitMQ
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}
