FROM python:3.8

ADD *.py /

RUN pip install asyncio-nats-client

CMD [ "python", "/entrypoint.py" ]