import asyncio, requests, sys
from nats.aio.client import Client as NATS

async def message_handler(msg):
    subject = msg.subject    
    data = msg.data.decode()
    print("Received a message on topic '{subject}' and message '{data}'".format(
        subject=subject, data=data))


async def dispose():
    
    await nc.close()

async def sendRequests(topic, message):
    await nc.connect("nats://172.17.0.1:4222", loop=loop)
    await nc.subscribe(topic, cb=message_handler)
    await asyncio.sleep(5)

    session = requests.Session()
    message = message.replace(",","%2C")
    url = f'http://172.17.0.1:5000/Notify?topic={topic}&messages={message}'
    session.get(url)

    print(f"Listening for requests on {topic} subject...")
    await asyncio.sleep(20)

nc = NATS()
topic = sys.argv[1]
message = sys.argv[2]

loop = asyncio.get_event_loop()
loop.run_until_complete(sendRequests(topic, message))
loop.run_until_complete(dispose())
loop.close()