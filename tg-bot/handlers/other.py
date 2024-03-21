from aiogram import types, Dispatcher
from pyrogram import Client


async def get(message: types.Message):
    app = Client(f'{message.from_user.id}')
    await app.connect()
    msgs = []
    async for dialog in app.get_dialogs():
        if (dialog.chat.type.value == 'supergroup' or dialog.chat.type.value == 'channel' or
                dialog.chat.type.value == 'group'):
            chat_id = dialog.chat.id
            async for msg in app.get_chat_history(chat_id=chat_id, limit=3):
                if ((msg.text or msg.caption) != None):
                    msgs_json = {'text': msg.text or msg.caption, 'msg_id': msg.id, 'group_id': chat_id}
                    msgs.append(msgs_json)
    session_string = await app.export_session_string()
    msgs_to_back = [{'session_string': session_string, 'msgs': msgs}]
    print(msgs_to_back)  # наверное request'ом запрос тут можно кинуть
    print(session_string)
    await app.disconnect()


async def start(message: types.Message):
    await message.reply('Hi')


def registration_handlers_other(dp: Dispatcher):
    dp.register_message_handler(get, commands='get')
    dp.register_message_handler(start, commands='start')
