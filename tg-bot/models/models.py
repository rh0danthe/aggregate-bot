from aiogram.dispatcher.filters.state import StatesGroup, State

class AuthState(StatesGroup):
    api_id = State()
    api_hash = State()
    phone_number = State()


class QueryState(StatesGroup):
    found = State()
    query = State()
