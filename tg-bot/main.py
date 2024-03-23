import uvicorn
from aiogram import executor
from bot import dp
from handlers import other, auth, start

start.registration_handlers_start(dp)
other.registration_handlers_other(dp)
auth.registration_handlers_auth(dp)

if __name__ == '__main__':
    executor.start_polling(dp, skip_updates=True)
