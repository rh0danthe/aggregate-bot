import pymorphy3
import nltk
from nltk.tokenize import word_tokenize
nltk.download('punkt')

def preprocess(text, punctuation_marks, morph):
    tokens = word_tokenize(text.lower())
    preprocessed_text = []
    for token in tokens:
        if token not in punctuation_marks:
            lemma = morph.parse(token)[0].normal_form
            preprocessed_text.append(lemma)
    return preprocessed_text

punctuation_marks = ['!', ',', '(', ')', ':', '-', '?', '.', '..', '...', '«', '»',
                         ';', '–', '--']
keys = ['утерять', 'потерять', 'найти']
morph = pymorphy3.MorphAnalyzer()

def check_accord(msgs): #сюда коллекцию
    #обработка коллекции
    #если это потеряшка то в новый массив ее надо добвить
    #возвращается обьект массив потеряшек
    new_msgs = []
    for msg in msgs.msgs:
        prep_text = preprocess(msg.content, punctuation_marks, morph)
        for word in prep_text:
            if word in keys:
                new_msgs.append(msg)
    new_object = msgs
    new_object.msgs = new_msgs
    return new_object



#def (массив из потеряшек), формирование нового и передеча в наташу
#смотреть по is_found элемента

def check_lost_found(msgs):
    new_msgs = []
    for msg in msgs.msgs:
        prep_text = preprocess(msg.content, punctuation_marks, morph)
        for word in prep_text:
            if msgs.is_found == 0:
                if word == 'потерять' or word == 'утерять':
                    new_msgs.append(msg)
            else:
                if word == 'найти':
                    new_msgs.append(msg)
    new_object = msgs
    new_object.msgs = new_msgs
    return new_object




