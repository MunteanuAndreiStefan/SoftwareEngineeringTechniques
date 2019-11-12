import json
import random
import requests

class Manager():

    def fake_tweet_score(self, tweet_id):

        content = requests.get(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles').content

        tweet_list = json.loads(content)

        for tweet in tweet_list:

            if int(tweet_id) == tweet['id']:

                print(f"Tweet data is in cache.")
                return tweet['credibilityScore']

        score = random.randrange(0, 100)

        cache_entry = {
            "id": int(tweet_id),
            "source": "Twitter",
            "credibilityScore": score,
            "userId": 0
        }

        json_content = json.dumps(cache_entry)

        print(f"NEW ENTRY\n{json_content}")

        r = requests.post(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles', headers={"Content-Type": "application/json", "Accept": "text/plain"}, json=cache_entry)

        return score

    def fake_user_score(self, user_id):
        return random.randrange(0, 100)