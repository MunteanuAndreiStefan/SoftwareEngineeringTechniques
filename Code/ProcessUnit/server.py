from flask import Flask, escape, request
from manager import Manager
import json
from logger import LogDecorator

app = Flask(__name__)
manager = Manager()


@app.route('/')
def index():
    return f'Hello!'


@app.route('/tweet/')
def fake_tweet():
    tweet_url = request.args.get("tweet_url")
    response = manager.analyze_tweet(tweet_url)

    return json.dumps(response, indent=4)


@app.route('/user/')
def fake_user():
    user_id = request.args.get("id")
    response = manager.analyze_user(user_id)

    return json.dumps(response, indent=4)


app.run(host='0.0.0.0', port=12345, debug=True)
