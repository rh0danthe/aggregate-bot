from fastapi import APIRouter
from models.models import MsgsFromBack
from pyrogram import Client

router = APIRouter()


@router.post('/send_to_smarta')
async def send_to_smarta(msgs_from_back: MsgsFromBack):
    msgs = msgs_from_back.msgs
    for msg in msgs:
        print(msg)
        # app = Client(f'{session_string[5]}', session_string=session_string)
        # await app.connect()
        # await app.send_message('me', 'дружок отработал')
        # async for msg in app.get_chat_history(msgs_from_back.chat_id):
        #     if (((msg.text or msg.caption) != None) and msg.id == msgs_from_back.msg_id):
        #         chat = await app.get_chat(msgs_from_back.chat_id)
        #         channel_name = msg.chat.username
        #         if chat.type.value == 'channel':
        #             await app.send_message('me', 'дружок отработал')
        #             await app.disconnect()
        #             return {'channel_name': channel_name,
        #                     'first_name': None,
        #                     'contacts': None,
        #                     'text': msgs_from_back.text}
        #         first_name = msg.from_user.first_name
        #         contacts = msg.from_user.id
        #         await app.send_message('me', 'дружок отработал')
        #         await app.disconnect()
        #         return {'channel_name': channel_name,
        #                 'first_name': first_name,
        #                 'contacts': contacts,
        #                 'text': msgs_from_back.text}
