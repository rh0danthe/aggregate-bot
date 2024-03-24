import natasha
import pymorphy3

morph = pymorphy3.MorphAnalyzer()

segmenter = natasha.Segmenter()
morph_vocab = natasha.MorphVocab()

emb = natasha.NewsEmbedding()
morph_tagger = natasha.NewsMorphTagger(emb)
syntax_parser = natasha.NewsSyntaxParser(emb)

def form_title(msgs):
    ms = []
    for msg in msgs.msgs:
        doc = natasha.Doc(msg.content)
        doc.segment(segmenter)
        doc.tag_morph(morph_tagger)
        doc.parse_syntax(syntax_parser)
        for token in doc.sents[0].syntax.tokens:
            #print(msg.content)
            if token.rel in ["nsubj:pass", "nsubj", "obj"]:
                msg.title = morph.parse(token.text)[0].normal_form
                #print(msg.title, token.rel)
                ms.append({'chat_id': msg.chat_id,
                           'message_id': msg.message_id,
                           'content': msg.content,
                           'title': msg.title})
                break
    return {'is_found': msgs.is_found,
            'session': msgs.session,
            'keywords': msgs.keywords,
            'msgs': ms}

'''doc = natasha.Doc('Потеряна Галина')

doc.segment(segmenter)
doc.tag_morph(morph_tagger)
doc.parse_syntax(syntax_parser)
print(doc.sents[0].syntax)
for token in doc.sents[0].syntax.tokens:
  #print(token)
  if token.rel == 'nsubj:pass':
    print('Что потеряно:', token.text)'''