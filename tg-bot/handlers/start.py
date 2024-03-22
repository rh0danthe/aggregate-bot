from aiogram import types, Dispatcher
from keyboards.keyboard import kb_auth


async def start(message: types.Message):
    await message.reply('Привет, для авторизации нажмите на кнопку', reply_markup=kb_auth)


def registration_handlers_start(dp: Dispatcher):
    dp.register_message_handler(start, commands='start')
