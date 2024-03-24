from pydantic import *
from typing import List


class Msg(BaseModel):
    chat_id: int
    message_id: int
    session: str
    content: str
    title: str


class MsgsFromBot(BaseModel):
    is_found: bool
    keywords: List[str]
    msgs: List[Msg]



