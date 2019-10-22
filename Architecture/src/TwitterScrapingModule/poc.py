import re
import json
import tweepy
from config import api_key, api_secret_key, access_token, access_secret_token

auth = tweepy.OAuthHandler(consumer_key=api_key, consumer_secret=api_secret_key)
auth.set_access_token(access_token, access_secret_token)
api = tweepy.API(auth)

# tweet_link = r'https://twitter.com/Texasinplay/status/1182291461934583813'
tweet_link = r'https://twitter.com/TeachFirst/status/1181245388663197696'
tweet_id = re.search('(?:.*)/status/(\d+)', tweet_link).group(1)
print(tweet_id)

tweet_status = api.get_status(tweet_id)
with open(tweet_id, 'w') as fd:
	json.dump(tweet_status._json, fd, indent=4)
