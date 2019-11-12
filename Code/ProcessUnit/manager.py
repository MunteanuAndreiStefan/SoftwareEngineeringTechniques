import re
import json
import random
import requests
from analyzers import TweetAnalyzerRandom, TweetAnalyzerHeuristic

class Manager():

    def __init__(self):

        self.analyzer = TweetAnalyzerRandom()

    def generate_tweet_response(self, tweet_url, score, username):
        return {
            "url": tweet_url,
            "score": score,
            "username": username
        }

    def analyze_tweet(self, tweet_url):

        username = re.findall(r'twitter.com/(\w+)/status/', tweet_url)[0]

        content = requests.get(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles').content

        tweet_list = json.loads(content)

        for tweet in tweet_list:

            if tweet_url == tweet['source']:

                print(f"Tweet data is in cache.")
                return self.generate_tweet_response(tweet_url, tweet['credibilityScore'], username)

        score = self.analyzer.analyze(tweet_url)

        cache_entry = {
            "id": 0,
            "source": tweet_url,
            "credibilityScore": score,
            "userId": 1
        }

        json_content = json.dumps(cache_entry)

        print(f"NEW ENTRY\n{json_content}")

        requests.post(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles', headers={"Content-Type": "application/json", "Accept": "text/plain"}, json=cache_entry)

        return self.generate_tweet_response(tweet_url, score, username)

    def analyze_user(self, user_id):
        # TODO: find twitter user fake api
        return random.randrange(0, 100)