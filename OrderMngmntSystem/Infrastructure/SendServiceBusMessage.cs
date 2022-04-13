//using Azure.Messaging.ServiceBus;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

//namespace OrderMngmntSystem.Infrastructure
//{
//    public class SendServiceBusMessage
//    {
//        private readonly ILogger _logger;

//        public IConfiguration _configuration;

//        public ServiceBusClient _client;
//        public ServiceBusSender _clientsender;

//        public SendServiceBusMessage(IConfiguration configuration,ILogger<SendServiceBusMessage> logger)
//        {
//            //_configuration = configuration;
//            _logger = logger;
//            var _ServiceBusconnectionString=_configuration["ServiceBusconnectionString"]
//        }
//    }
//}
