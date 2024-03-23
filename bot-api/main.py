import uvicorn
from fastapi import FastAPI
from routers.router import router

fast_app = FastAPI(
    title='Bebrik'
)

fast_app.include_router(router)
