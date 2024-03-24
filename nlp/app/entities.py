from pydantic import *
from typing import List


class Msg(BaseModel):
    chat_id: int
    message_id: int
    content: str
    title: str


class MsgsFromBot(BaseModel):
    is_found: bool
    session: str
    keywords: List[str]
    msgs: List[Msg]



