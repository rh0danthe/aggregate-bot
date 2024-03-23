import uvicorn
from aiogram import executor
from fastapi import FastAPI
from routers.router import router
from bot import dp
from handlers import other, auth, start

fast_app = FastAPI(
    title='Bebrik'
)

start.registration_handlers_start(dp)
other.registration_handlers_other(dp)
auth.registration_handlers_auth(dp)

fast_app.include_router(router)
if __name__ == '__main__':
    uvicorn.run(fast_app, host='0.0.0.0', port='5466')
    executor.start_polling(dp, skip_updates=True)
