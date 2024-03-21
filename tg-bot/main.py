from aiogram import executor
from fastapi import FastAPI
from routers.router import router
from bot import dp
from handlers import other, auth

fast_app = FastAPI(
    title='Bebrik'
)

other.registration_handlers_other(dp)
auth.registration_handlers_auth(dp)
fast_app.include_router(router)
if __name__ == '__main__':
    executor.start_polling(dp, skip_updates=True)
