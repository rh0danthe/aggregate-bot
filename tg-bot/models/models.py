from typing import List

from aiogram.dispatcher.filters.state import StatesGroup, State
from pydantic import BaseModel


class Msgs(BaseModel):
    msg_id: int
    group_id: int


class MsgsFromBack(BaseModel):
    session_string: str
    msgs: List[Msgs]


class AuthState(StatesGroup):
    api_id = State()
    api_hash = State()
    phone_number = State()
