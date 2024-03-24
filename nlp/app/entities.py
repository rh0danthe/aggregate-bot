from pydantic import *
from typing import List


class Msgs(BaseModel):
    title: str
    chat_id: int
    message_id: int
    content: str


class MsgsFromBot(BaseModel):
    is_found: bool
    session: str
    keywords: List[str]
    msgs: List[Msgs]


# class MsgsFromNlp(MsgsFromBot):
#     title: str
