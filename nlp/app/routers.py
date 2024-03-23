#from main import app
from fastapi import APIRouter
# from nlp import *
from . import entities
#from entities import MsgsFromBot

#@app.get("/backend/approved")

router = APIRouter()
@router.get("/backend/from_bot")
async def read_root(msgs_from_bot: entities.MsgsFromBot):
    return msgs_from_bot

