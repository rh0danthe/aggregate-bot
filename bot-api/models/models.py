from typing import List
from pydantic import BaseModel


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
    msgs: List[Msgs]