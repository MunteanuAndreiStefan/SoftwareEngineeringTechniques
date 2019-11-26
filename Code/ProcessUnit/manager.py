import re
import json
import requests
from analyzers import TweetAnalyzerRandom, UserAnalyzerRandom
from config import Config as cfg
from logger import LogDecorator

class Manager():

    def __init__(self):

        self.tweet_analyzer = TweetAnalyzerRandom()
        self.user_analyzer = UserAnalyzerRandom()

    @LogDecorator()
    def generate_tweet_response(self, tweet_url, score, username):
        return {
            "url": tweet_url,
            "score": score,
            "username": username
        }

    @LogDecorator()
    def analyze_tweet(self, tweet_url):

        username = re.findall(r'twitter.com/(\w+)/status/', tweet_url)[0]

        content = requests.get(cfg.tweet_cache_url).content

        tweet_list = json.loads(content)

        for tweet in tweet_list:

            if tweet_url == tweet['source']:

                print(f"Tweet data is in cache.")
                return self.generate_tweet_response(tweet_url, tweet['credibilityScore'], username)

        score = self.tweet_analyzer.analyze(tweet_url)

        cache_entry = {
            "id": 0,
            "source": tweet_url,
            "credibilityScore": score,
            "userId": 1
        }

        json_content = json.dumps(cache_entry)

        print(f"NEW ENTRY\n{json_content}")

        requests.post(cfg.tweet_cache_url, headers={"Content-Type": "application/json", "Accept": "text/plain"}, json=cache_entry)

        return self.generate_tweet_response(tweet_url, score, username)

    @LogDecorator()
    def analyze_user(self, user_id):
        return self.user_analyzer.analyze(user_id)