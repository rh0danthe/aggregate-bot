from typing import Union
from fastapi import FastAPI
#from . import routers
import routers

app = FastAPI()
app.include_router(routers.router)



