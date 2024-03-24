import natasha

segmenter = natasha.Segmenter()
morph_vocab = natasha.MorphVocab()

emb = natasha.NewsEmbedding()
morph_tagger = natasha.NewsMorphTagger(emb)
syntax_parser = natasha.NewsSyntaxParser(emb)

def form_title(msgs):
    #print('JOPA')
    for msg in msgs.msgs:
        doc = natasha.Doc(msg.content)
        doc.segment(segmenter)
        doc.tag_morph(morph_tagger)
        doc.parse_syntax(syntax_parser)
        for token in doc.sents[0].syntax.tokens:

            if token.rel == "nsubj:pass":
                msg.title = 'Утеряно: ' + token.text

    return msgs

'''doc = natasha.Doc('Потеряна Галина')

doc.segment(segmenter)
doc.tag_morph(morph_tagger)
doc.parse_syntax(syntax_parser)
print(doc.sents[0].syntax)
for token in doc.sents[0].syntax.tokens:
  #print(token)
  if token.rel == 'nsubj:pass':
    print('Что потеряно:', token.text)'''