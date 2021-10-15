namespace Notifier.Services.Messaging
{
    public interface INatsService
    {
        void PublishMessage(string topic, string messages);
    }
}