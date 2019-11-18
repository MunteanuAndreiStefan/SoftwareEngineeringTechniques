from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
from nltk.tokenize import sent_tokenize
from nltk.stem import WordNetLemmatizer
import numpy as np
import os
import gensim

def sentence_tokenize(text):
    return sent_tokenize(text)

def tokenize(text):
    tokens = word_tokenize(text)
    words = [word for word in tokens if word.isalpha()]
    return words

def remove_stop_words(words):
    stop_words = set(stopwords.words('english')) 
    return [w for w in words if not w in stop_words]

def analyze(subject, data):

    words = word_tokenize(subject)
    sentences = sent_tokenize(subject)

    words = [[w.lower() for w in word_tokenize(text)] for text in sentences]

    dictionary = gensim.corpora.Dictionary(words)

    # print(dictionary.token2id)

    corpus = [dictionary.doc2bow(words) for words in words]

    tfidf = gensim.models.TfidfModel(corpus)
    for doc in tfidf[corpus]:
        print([[dictionary [id], np.around(freq, decimals=2)] for id, freq in doc])

    if not os.path.exists('workdir'):
        os.mkdir('workdir')

    sims = gensim.similarities.Similarity('workdir/',tfidf[corpus], num_features=len(dictionary))

    results = []

    for line in data:
        query_doc = [w.lower() for w in word_tokenize(line)]
        query_doc_bow = dictionary.doc2bow(query_doc)

        query_doc_tf_idf = tfidf[query_doc_bow]
        
        print(sims[query_doc_tf_idf], line, np.average(sims[query_doc_tf_idf])) 

        results.append(sims[query_doc_tf_idf])

example = 'The 2019 Soul Train Music Awards are in the books, ending in a big night for Chris Brown and his song with Drake, "No Guidance," which took home three trophies. Here\'s the full list of winners.'

analyze(
    example,
    [
        'Chris brows won three prizez at the 2019 edition of The Soul Train Music Awards.',
        'Chris Brown and Drake are the winners of the 2019 Soul Train Music Awards.',
        'Drake has started recording for his 2019 album.',
        'The amount of hybrid vehicles has doubled since last year',
        'Grass is green',
        'I have a cat and a dog and I love both of them'
    ]
)

print(remove_stop_words(tokenize(example)))