from fastapi import APIRouter
from models.models import MsgsFromNatasha
from pyrogram import Client

router = APIRouter()


@router.post('/send')
async def send_posts(msgs_from_natasha: MsgsFromNatasha):
    session_string = msgs_from_natasha.session_string
    msgs = msgs_from_natasha.msgs
    app = Client('123', session_string=session_string)
    await app.connect()
    for msg in msgs:
        url = msg.url
        await app.send_message(chat_id='me', text=url)
    await app.disconnect()
