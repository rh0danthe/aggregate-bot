from pydantic import *
class MsgsFromBot(BaseModel):
    is_found: bool
    chat_id: int
    message_id: int
    session: str
    content: str
    keywords: list[str]

class MsgsFromNlp(MsgsFromBot):
    title: str
