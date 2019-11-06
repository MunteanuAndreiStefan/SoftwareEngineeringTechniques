import threading
import logging
import time
import redis

logging.basicConfig(filename='process.log', filemode='a', level='INFO',
                    format='%(asctime)s - %(levelname)s - %(message)s')

redis_client = redis.StrictRedis(host='localhost', port=6379, db=0)


def process_tweet(tweet):
    pass


def worker():
    while redis_client.llen('posts') != 0:
        tweet = redis_client.rpop('posts')
        process_tweet(tweet)
    else:
        time.sleep(10)


if __name__ == '__main__':
    for i in range(10):
        x = threading.Thread(target=worker)
        x.start()
