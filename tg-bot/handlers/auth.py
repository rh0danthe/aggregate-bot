from aiogram.dispatcher import FSMContext
from aiogram import types, Dispatcher
from models.models import AuthState
from pyrogram import Client

api_id = 0
api_hash = ''
phone_number = ''
menu = 2
hash = None
app = None


# @dp.message_handler(commands='auth')
async def start(message: types.Message):
    await message.reply('Привет, для начала введите свой api_id')
    await AuthState.api_id.set()


# @dp.message_handler(state=AuthState.api_id)
async def get_api_id(message: types.Message, state: FSMContext):
    await state.update_data(api_id=message.text)
    await message.reply('Введите api_hash')
    await AuthState.next()


# @dp.message_handler(state=AuthState.api_hash)
async def get_api_hash(message: types.Message, state: FSMContext):
    await state.update_data(api_hash=message.text)
    await message.reply('Введите номер телефона')
    await AuthState.next()


# @dp.message_handler(state=AuthState.phone_number)
async def get_phone_number(message: types.Message, state: FSMContext):
    global api_id
    global api_hash
    global phone_number
    global menu
    await state.update_data(phone_number=message.text)
    data = await state.get_data()
    api_id = data['api_id']
    api_hash = data['api_hash']
    phone_number = data['phone_number']
    await state.finish()
    await message.reply('Напишите "Получить код"')
    menu = 0


async def auth(value, username):
    global menu
    global hash
    global app
    if menu == 0:
        app = Client(f'{username}', api_id=api_id, api_hash=api_hash, phone_number=phone_number)
        await app.connect()
        hash = await app.send_code(phone_number=phone_number)
    elif menu == 1:
        ch = hash.phone_code_hash
        await app.sign_in(phone_number=phone_number, phone_code_hash=ch, phone_code=value)
        await app.disconnect()


# @dp.message_handler(types.Message)
async def get_code(message: types.Message):
    global menu
    if menu == 0:
        await auth(0, message.from_user.id)
        await message.reply('Отправьте код с цифрами через пробел')
        menu = 1
    elif menu == 1:
        code = message.text
        code = code.replace(' ', '')
        await auth(code, 0)
        await message.reply('Успешная авторизация')
        menu = 2


def registration_handlers_auth(dp: Dispatcher):
    dp.register_message_handler(start, commands='auth')
    dp.register_message_handler(get_api_id, state=AuthState.api_id)
    dp.register_message_handler(get_api_hash, state=AuthState.api_hash)
    dp.register_message_handler(get_phone_number, state=AuthState.phone_number)
    dp.register_message_handler(get_code, types.Message)
