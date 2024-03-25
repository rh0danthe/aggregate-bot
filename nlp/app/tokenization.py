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
    #print(preprocessed_text)
    return preprocessed_text


punctuation_marks = ['!', ',', '(', ')', ':', '-', '?', '.', '..', '...', '«', '»',
                     ';', '–', '--']
keys = ['утерять', 'потерять', 'найти', 'пропасть', 'потеряться']
morph = pymorphy3.MorphAnalyzer()

def check_accord(msgs): #сюда коллекцию
    #обработка коллекции
    #если это потеряшка то в новый массив ее надо добвить
    #возвращается обьект массив потеряшек
    new_msgs = []
    for msg in msgs.msgs:
        checked = False
        prep_text = preprocess(msg.content, punctuation_marks, morph)
        for word in prep_text:
            if word in keys:
                if not checked:
                    new_msgs.append(msg)
                    checked = True
    new_object = msgs
    new_object.msgs = new_msgs
    return new_object



#def (массив из потеряшек), формирование нового и передеча в наташу
#смотреть по is_found элемента

def check_lost_found(msgs):
    new_msgs = []
    for msg in msgs.msgs:
        #print('msg:', msg.content)
        prep_text = preprocess(msg.content, punctuation_marks, morph)
        for word in prep_text:
            if not msgs.is_found:
                if word in ['потерять', 'утерять','пропасть', 'потеряться']:
                    new_msgs.append(msg)
                    break
            else:
                if word == 'найти':
                    new_msgs.append(msg)
                    break
    new_object = msgs
    new_object.msgs = new_msgs
    return new_object