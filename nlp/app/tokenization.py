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

def check_keys(text):
    status = False
    punctuation_marks = ['!', ',', '(', ')', ':', '-', '?', '.', '..', '...', '«', '»',
                         ';', '–', '--']
    keys = ['утерять', 'потерять', 'найти']
    morph = pymorphy3.MorphAnalyzer()
    prep_text = preprocess(text, punctuation_marks, morph)
    for word in prep_text:
        if word in keys:
            status = True
    return status

#print(check_keys('Я пизда гавнопроебная потеряла паспорт'))