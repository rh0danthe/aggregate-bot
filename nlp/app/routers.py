#from main import app
from fastapi import APIRouter
from . import entities #from entities import MsgsFromBot
from . import tokenization #import check_accord, check_lost_found
from . import nlp_unit
import requests

#@app.get("/backend/approved")

router = APIRouter()
@router.post("/backend/from_bot", response_model=entities.MsgsFromBot)
async def from_bot(msgs_from_bot: entities.MsgsFromBot): #collection
    #сортировка по is_found
    accorded = tokenization.check_accord(msgs_from_bot)
    lost_found = tokenization.check_lost_found(accorded)
    formed = nlp_unit.form_title(lost_found)
    r = requests.post('http://api:8080/backend/approved', json=formed)
    return formed
