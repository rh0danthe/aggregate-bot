from typing import List
from aiogram.dispatcher.filters.state import StatesGroup, State
from pydantic import BaseModel
from typing import Optional


# class Msgs(BaseModel):
#     title: str
#     text: str
#     msg_id: int
#     group_id: int
#     url: str
#     nickname: str
#     contacts: Optional[str] = None

class Msgs(BaseModel):
    title: str
    chat_id: int
    msg_id: int
    session_string: str
    text: str


class MsgsFromBack(BaseModel):
    msgs = List[Msgs]


class AuthState(StatesGroup):
    api_id = State()
    api_hash = State()
    phone_number = State()


class QueryState(StatesGroup):
    found = State()
    query = State()
