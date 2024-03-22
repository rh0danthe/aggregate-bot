from typing import List
from aiogram.dispatcher.filters.state import StatesGroup, State
from pydantic import BaseModel
from typing import Optional


class Msgs(BaseModel):
    title: str
    text: str
    msg_id: int
    group_id: int
    url: str
    nickname: str
    contacts: Optional[str] = None


class MsgsFromNatasha(BaseModel):
    flag: bool
    query: List
    session_string: str
    msgs: List[Msgs]


class AuthState(StatesGroup):
    api_id = State()
    api_hash = State()
    phone_number = State()


class QueryState(StatesGroup):
    found = State()
    query = State()
