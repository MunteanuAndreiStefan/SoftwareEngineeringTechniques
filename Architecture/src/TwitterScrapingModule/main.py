import time
import tweepy
import pymongo
import logging
from config import api_key, api_secret_key, access_token, access_secret_token

auth = tweepy.OAuthHandler(consumer_key=api_key, consumer_secret=api_secret_key)
auth.set_access_token(access_token, access_secret_token)
api = tweepy.API(auth)

mongo_client = pymongo.MongoClient()
db = mongo_client.TwitterFakeNewsDetector
posts_collection = db.posts
users_collection = db.users

logging.basicConfig(filename='crawler.log', filemode='a', format='%(asctime)s - %(levelname)s - %(message)s')

INTERESTING_SUBJECTS = ["America", "Apple", "Samsung"]  # keywords


def get_interesting_subject():
    s = INTERESTING_SUBJECTS.pop(0)
    INTERESTING_SUBJECTS.append(s)
    return s


def crawl_twitter():
    # TODO retry decorator in case api request fails

    while True:
        keyword = get_interesting_subject()
        search_results = api.search(q=keyword, lang="en", truncated=False)
        logging.info(msg="API request - Searched for {} keyword".format(keyword))
        for result in search_results:
            tweet_id = result.id
            # TODO check if tweet id already in database
            tweet_status = api.get_status(tweet_id)
            logging.info(msg="API request - Searched for tweed id {}".format(tweet_id))
            user_id = tweet_status._json['user']['id']
            # TODO check if user id already in database
            user = api.get_user(user_id)
            logging.info(msg="API request - Searched for user id".format(user_id))
            users_collection.insert_one(user._json)
            posts_collection.insert_one(tweet_status._json)
        logging.info(msg="Sleepin 5 minutes..")
        time.sleep(5 * 60)


if __name__ == '__main__':
    crawl_twitter()
