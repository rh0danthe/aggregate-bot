from aiogram import types, Dispatcher
from aiogram.dispatcher import FSMContext
from pyrogram import Client
from keyboards.keyboard import kb_skip, kb
from models.models import QueryState


async def start(message: types.Message):
    await message.reply('Выберите потерял/нашел', reply_markup=kb)
    await QueryState.found.set()


async def get_info(message: types.Message, state: FSMContext):
    if message.text.lower() == 'потерял':
        await state.update_data(found=0)
    elif message.text.lower() == 'нашёл':
        await state.update_data(found=1)
    await message.reply('Напишите что именно вы потеряли/нашли или нажмите "Пропустить"', reply_markup=kb_skip)
    await QueryState.next()


async def get_query(message: types.Message, state: FSMContext):
    if message.text.lower() == 'пропустить':
        await state.update_data(query='skip')
        data = await state.get_data()
        await get(user_id=message.from_user.id, query=data['query'], found=data['found'])
    else:
        await state.update_data(query=message.text)
        data = await state.get_data()
        await get(user_id=message.from_user.id, query=data['query'], found=data['found'])
    await state.finish()


async def get(user_id, query, found):
    app = Client(f'{user_id}')
    await app.connect()
    msgs = []
    print('fdfdfdfd')
    async for dialog in app.get_dialogs():
        if (dialog.chat.type.value == 'supergroup' or dialog.chat.type.value == 'channel' or
                dialog.chat.type.value == 'group'):
            chat_id = dialog.chat.id
            async for msg in app.get_chat_history(chat_id=chat_id, limit=1):
                if ((msg.text or msg.caption) != None):
                    msgs_json = {'text': msg.text or msg.caption, 'msg_id': msg.id, 'group_id': chat_id, 'url': msg.link}
                    msgs.append(msgs_json)
    session_string = await app.export_session_string()
    msgs_to_back = {'session_string': session_string, 'msgs': msgs}
    print(msgs_to_back)  # наверное request'ом запрос тут можно кинуть
    print(session_string)
    await app.disconnect()


def registration_handlers_other(dp: Dispatcher):
    dp.register_message_handler(start, commands='get')
    dp.register_message_handler(get_info, lambda msg: msg.text.lower() == 'потерял' or msg.text.lower() == 'нашёл',
                                state=QueryState.found)
    dp.register_message_handler(get_query, types.Message, state=QueryState.query)
