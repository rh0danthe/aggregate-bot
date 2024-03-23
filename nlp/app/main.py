from typing import Union
from fastapi import FastAPI
from . import nlp

app = FastAPI()

@app.get("/{lost_json}")
async def read_root(lost_json: str):
    return {"lost": nlp.lost(lost_json)}


@app.get("/")
async def ping():
    return {"pong":":)"}