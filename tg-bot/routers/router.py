from fastapi import APIRouter
from models.models import MsgsFromBack
from pyrogram import Client

router = APIRouter()

@router.post('/send')
async def send_posts(msgs_from_back: MsgsFromBack):
    session_string = msgs_from_back.session_string
    msgs = msgs_from_back.msgs
    app = Client('123', session_string=session_string)
    await app.connect()
    for msg in msgs:
        msg_id = msg.msg_id
        group_id = msg.group_id
        await app.forward_messages(chat_id='me', from_chat_id=group_id, message_ids=msg_id)
    await app.disconnect()