# from main import app
from fastapi import APIRouter
from nlp_unit import form_title
from entities import MsgsFromBot
from tokenization import check_accord, check_lost_found
import requests
import json
from pydantic import Json
from pyrogram import Client

# @app.get("/backend/approved")

router = APIRouter()


@router.post("/backend/from_bot")
async def from_bot(msgs_from_bot: MsgsFromBot):  # collection
    # сортировка по is_found
    accorded = check_accord(msgs_from_bot)
    lost_found = check_lost_found(accorded)
    formed = form_title(lost_found)
    # session_string = formed.session
    # app = Client(name=f'{session_string[5]}', session_string=session_string)
    # await app.connect()
    # for msg in formed.msgs:
    #     async for ms in app.get_chat_history(msg.chat_id):
    #         if (((ms.text or ms.caption) != None) and ms.id == msg.message_id):
    #             chat = await app.get_chat(msg.chat_id)
    #             channel_name = ms.chat.username
    #             if chat.type.value == 'channel':
    #                 await app.disconnect()
    #                 formed['msgs']['channel_name'] = channel_name
    #            first_name = ms.from_user.first_name
    #            contacts = ms.from_user.id
    #            await app.send_message('me', 'дружок отработал')
    #            await app.disconnect()
    #        return {'channel_name': channel_name,
    #               'first_name': first_name,
    #              'contacts': contacts,
    #             'text': msg.text}

    response = requests.post('https://api/backend/approved', json=formed)
    print(formed)
    return response.json()
