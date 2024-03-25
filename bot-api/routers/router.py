from fastapi import APIRouter
from models.models import MsgsFromBack
from pyrogram import Client

router = APIRouter()


@router.post('/send_to_smarta')
async def send_to_smarta(msgs_from_back: MsgsFromBack):
    print('sadfaafddgfd')
    msgs = msgs_from_back.msgs
    session_string = msgs_from_back.session_string
    app = Client(f'{session_string[5]}', session_string=session_string)
    await app.connect()
    for msg in msgs:
        await app.send_message('me', 'дружок отработал')
    await app.disconnect()
 #       async for ms in app.get_chat_history(msg.chat_id):
 #           if (((ms.text or ms.caption) != None) and ms.id == msg.msg_id):
 #               chat = await app.get_chat(msg.chat_id)
 #               channel_name = ms.chat.username
 #               if chat.type.value == 'channel':
 #                  await app.send_message('me', 'дружок отработал')
  #                  await app.disconnect()
   #                 return {'channel_name': channel_name,
     #                       'first_name': None,
      #                      'contacts': None,
       #                     'text': msgs_from_back.text}
        #        first_name = ms.from_user.first_name
         #       contacts = ms.from_user.id
          #      await app.send_message('me', 'дружок отработал')
           #     await app.disconnect()
            #    return {'channel_name': channel_name,
             #           'first_name': first_name,
              #          'contacts': contacts,
               #         'text': msg.text}