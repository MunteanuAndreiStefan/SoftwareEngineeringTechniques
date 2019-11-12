import json
import random
import requests

class Manager():

    def fake_tweet_score(self, tweet_url):

        content = requests.get(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles').content

        tweet_list = json.loads(content)

        for tweet in tweet_list:

            if tweet_url == tweet['source']:

                print(f"Tweet data is in cache.")
                return tweet['credibilityScore']

        score = random.randrange(0, 100)

        cache_entry = {
            "id": 0,
            "source": tweet_url,
            "credibilityScore": score,
            "userId": 1
        }

        json_content = json.dumps(cache_entry)

        print(f"NEW ENTRY\n{json_content}")

        requests.post(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles', headers={"Content-Type": "application/json", "Accept": "text/plain"}, json=cache_entry)

        return score

    def fake_user_score(self, user_id):
        return random.randrange(0, 100)