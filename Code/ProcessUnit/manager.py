import json
import random
import requests

class Manager():

    def fake_tweet_score(self, tweet_id):

        content = requests.get(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles').content

        tweet_list = json.loads(content)

        print(f"CACHED TWEETS:\n{tweet_list}")

        for tweet in tweet_list:

            if int(tweet_id) == tweet['id']:

                return tweet['credibilityScore']


        score = random.randrange(0, 100)

        cache_entry = {
            "id": int(tweet_id),
            "source": "Twitter",
            "credibilityScore": score,
            "userId": 0
        }

        json_content = json.dumps(cache_entry, indent=4)

        print(f"NEW ENTRY\n{json_content}")

        r = requests.post(r'https://fakenewsdetection.azurewebsites.net/api/NewsArticles', json=json_content)    
        print(f"RESPONSE\n{json.dumps(r.json(), indent=4)}")

        return score

    def fake_user_score(self, user_id):
        return random.randrange(0, 100)

m = Manager()

m.fake_tweet_score('100')