FROM python:3.11

WORKDIR /tg-bot

COPY ./requirements.txt /tg-bot/requirements.txt

RUN pip install --no-cache-dir --upgrade -r /tg-bot/requirements.txt

COPY . .

EXPOSE 88

CMD ["python", "main.py"]