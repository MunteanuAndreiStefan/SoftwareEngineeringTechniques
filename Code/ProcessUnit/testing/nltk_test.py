from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
from nltk.stem import WordNetLemmatizer

example_sentence = ".@Hatewatch reviewed over 900 previously private emails Stephen Miller sent to Breitbart during the run-up to the 2016 election.\nMiller shared white nationalist material. He pushed racist stories.\nRead part 1 of our investigation here:"

print(example_sentence)

stop_words = set(stopwords.words("english"))

words = word_tokenize(example_sentence)

filtered = [w for w in words if not w in stop_words]

lemmatizer = WordNetLemmatizer()

for w in filtered:
    print(lemmatizer.lemmatize(w))