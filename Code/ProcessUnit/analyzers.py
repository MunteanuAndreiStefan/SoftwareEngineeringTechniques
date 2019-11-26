import random
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
        return 0

### User analyzers

class UserAnalyzer:
    
    def __init__(self):
        pass

    def analyze(self, user_id):
        pass
    
   
class UserAnalyzerRandom(UserAnalyzer):
    
    @LogDecorator()
    def analyze(self, user_id):
        return random.randrange(0, 100)
