import random
from twitter_utils import get_tweet_data
from semantic_analyzer import SemanticAnalyzer
from logger import LogDecorator

### Tweet analyzers

class TweetAnalyzer:
    
    def __init__(self):
        pass

    @LogDecorator()
    def get_tweet_content(self):
        # TODO get tweet content
        return ''

    def analyze(self, tweet_url):
        pass


class TweetAnalyzerRandom(TweetAnalyzer):
    
    @LogDecorator()
    def analyze(self, tweet_url):
        return random.randrange(0, 100)


class TweetAnalyzerHeuristic(TweetAnalyzer):

    @LogDecorator()
    def analyze(self, tweet_url):
        return 0


class TweetAnalyzerML(TweetAnalyzer):

    @LogDecorator()
    def analyze(self, tweet_url):
        return 0


class TweetAnalyzerSemantic(TweetAnalyzer):

    @LogDecorator()
    def analyze(self, tweet_url):

        tweet_data = get_tweet_data(tweet_url)

        sman = SemanticAnalyzer()

        score = sman.analyze(tweet_data['text'])

        return score

### User analyzers

class UserAnalyzer:
    
    def __init__(self):
        pass

    def analyze(self, user_id):
        pass
    
   
class UserAnalyzerRandom(UserAnalyzer):
    
    @LogDecorator()
    def analyze(self, username):
        return random.randrange(0, 100)
