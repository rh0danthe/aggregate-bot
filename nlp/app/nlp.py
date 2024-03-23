import natasha

segmenter = natasha.Segmenter()
morph_vocab = natasha.MorphVocab()

emb = natasha.NewsEmbedding()
morph_tagger = natasha.NewsMorphTagger(emb)
syntax_parser = natasha.NewsSyntaxParser(emb)



def lost(text):
    doc = natasha.Doc(text)
    doc.segment(segmenter)
    doc.tag_morph(morph_tagger)
    doc.parse_syntax(syntax_parser)
    for token in doc.sents[0].syntax.tokens:
        if token.rel == 'nsubj:pass':
            return token.text