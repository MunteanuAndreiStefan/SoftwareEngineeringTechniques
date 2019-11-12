from flask import Flask, escape, request
from manager import Manager
import json

app = Flask(__name__)
manager = Manager()

@app.route('/')
def index():
    return f'Hello!'

@app.route('/tweet/')
def fake_tweet():

    tweet_id = request.args.get("id")
    score = manager.fake_tweet_score(tweet_id)
    
    response = {
        "id": tweet_id,
        "score": score
    }

    return json.dumps(response, indent=4)

@app.route('/user/')
def fake_user():

    user_id = request.args.get("id")
    score = manager.fake_user_score(user_id)
    
    response = {
        "id": user_id,
        "score": score
    }

    return json.dumps(response, indent=4)

app.run(host='0.0.0.0', port=12345, debug=True)