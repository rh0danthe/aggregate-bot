FROM python:3.11

WORKDIR /fastapiservice

COPY ./requirements.txt /code/requirements.txt

RUN pip install --no-cache-dir --upgrade -r /code/requirements.txt

COPY . .

EXPOSE 5266

CMD uvicorn main:fast_app --host 127.0.0.1 --port 5466
CMD ["python", "main.py"]