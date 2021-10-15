using System.Collections.Generic;
using System.Text;
using NATS.Client;

namespace Notifier.Services.Messaging
{
    public class NatsService : INatsService
    {
        private readonly IConnection _connection;

        public NatsService()
        {
            var factory = new ConnectionFactory();
            _connection = factory.CreateConnection();
        }

        public void PublishMessage(string topic, string message)
        {
            _connection.Publish(topic, Encoding.UTF8.GetBytes(message));
        }
    }

    
}
