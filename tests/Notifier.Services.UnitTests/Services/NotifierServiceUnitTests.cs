using System;
using Moq;
using Notifier.Services;
using Notifier.Services.Messaging;
using Xunit;

namespace Notifier.Services.UnitTests
{
    public class NotifierServiceUnitTests
    {
        private NotifierService _notifierService;
        private Mock<INatsService> _natsServiceMock;
        private MockRepository _mockRepository;

        public NotifierServiceUnitTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _natsServiceMock = _mockRepository.Create<INatsService>();
            _notifierService = new NotifierService(_natsServiceMock.Object);
        }

        [Fact]
        public void OnPublish_ShouldPublishMessageOnTopic()
        {
            //arrange
            var topic = "topic";
            var message = "message";

            _natsServiceMock.Setup(_ => _.PublishMessage(topic, message));

            //act
            _notifierService.Publish(topic, message);

            //assert
            _mockRepository.VerifyAll();
        }

        [Theory]
        [InlineData("message1,message2", 2)]
        [InlineData("message1,message2,message3,message4", 4)]
        [InlineData("message1,message2,message3", 3)]
        public void OnPublish_WhenMoreThanOneMessage_ShouldPublishAllMessages(string messages, int messageCount)
        {
            //arrange
            var topic = "topic";

            _natsServiceMock.Setup(_ => _.PublishMessage(topic, It.IsAny<string>()));

            //act
            _notifierService.Publish(topic, messages);

            //assert
            _mockRepository.VerifyAll();
            _natsServiceMock.Verify(_ => _.PublishMessage(topic, It.IsAny<string>()), Times.Exactly(messageCount));
        }
    }
}
