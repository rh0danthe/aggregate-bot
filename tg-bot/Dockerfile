FROM python:3.11

WORKDIR /fastapiservice

COPY ./requirements.txt /code/requirements.txt

RUN pip install --no-cache-dir --upgrade -r /code/requirements.txt

COPY . .

EXPOSE 88

CMD ["python", "main.py"]