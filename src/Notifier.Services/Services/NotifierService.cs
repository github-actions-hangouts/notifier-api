using System;
using System.Threading.Tasks;
using Notifier.Services.Messaging;

namespace Notifier.Services
{
    public class NotifierService : INotifierService
    {
        private readonly INatsService _natsService;

        public NotifierService(INatsService natsService)
        {
            _natsService = natsService;
        }

        public Task Publish(string topic, string messages)
        {
            var messageList = messages.Split(",");

            foreach (var msg in messageList)
            {
                _natsService.PublishMessage(topic, msg.Trim());
            }
            return Task.CompletedTask;
        }
    }
}
