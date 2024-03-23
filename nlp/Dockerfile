FROM python:3.12
WORKDIR /nlp
COPY ./requirements.txt /nlp/requirements.txt
RUN pip install --no-cache-dir --upgrade -r /nlp/requirements.txt
COPY ./app /nlp/app
EXPOSE 5058
CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "5068"]