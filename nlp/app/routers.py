#from main import app
from fastapi import APIRouter
from nlp_unit import form_title
from entities import MsgsFromBot
from tokenization import check_accord, check_lost_found
import requests

#@app.get("/backend/approved")

router = APIRouter()
@router.post("/backend/from_bot")
async def from_bot(msgs_from_bot: MsgsFromBot): #collection
    #сортировка по is_found
    accorded = check_accord(msgs_from_bot)
    lost_found = check_lost_found(accorded)
    formed = form_title(lost_found)
    #requests.post('http://api:8080/backend/approved')
    return formed
