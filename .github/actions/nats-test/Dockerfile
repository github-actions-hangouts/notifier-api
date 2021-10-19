FROM python:3.8

ADD *.py /

RUN pip install asyncio-nats-client
RUN pip install requests

ENTRYPOINT [ "python", "/entrypoint.py" ]