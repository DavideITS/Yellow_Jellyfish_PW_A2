const express = require('express');
const bodyParser = require('body-parser');
const MongoClient = require('mongodb').MongoClient

const app = express();
var db;
var users;
const uri = "mongodb://127.0.0.1:27017";
const client = new MongoClient(uri);

app.set('view engine', 'ejs');

app.use(bodyParser.urlencoded({
    extended: true
}))

app.get('/', (req, res) => {
    res.sendFile(__dirname + '/index.html')
})

app.post('/login', (req, res) => {
    //console.log(req.body)

    db.collection('Users').find().toArray(function (err, results) {
        if (err) {
            return console.log(err)
        } else {
            users = results

            if (users != undefined) {
                if (users.length > 0) {
                    for (let index = 0; index < users.length; index++) {
                        if (users[index].nick === req.body.username && users[index].password === req.body.password) {
                            var role = users[index].role;
                            var querySearchNrTrain = { conductor: req.body.username };
                            var resultQueryNrTrain = db.collection('Trains').findOne(querySearchNrTrain, function (err, results) {
                                if (err) {
                                    return console.log(err)
                                } else {
                                    console.log(results)
                                    var nrTrain = results.nrTrain;
                                    console.log(nrTrain)
                                    var arrayToSend = {};
                                    /*
                                    for (let index = 0; index < results.nrWagon; index++) {
                                        var queryForDb = { nrTrain: nrTrain, nrWagon: (index+1)};
                                        //DA FINIRE
                                        var jsonFromDb = db.collection('TrainLiveData').ord .findOne(queryForDb)
                                        arrayToSend[index + 1].push()
                                    }
                                    console.log(arrayToSend);
                                    for (let index = 0; index < array.length; index++) {
                                        const element = array[index];
                                        
                                    }
                                    await db.collection('TrainLiveData').findOne()
                                    */
                                    res.render('index.ejs', {arrayNrWagon: arrayToSend, nrTrain: nrTrain, role: role})
                                }
                            });
                        }
                    }
                }else{
                    return console.log("No Username and Password found")
                }
            } else {
                console.log("--->")
            }
        }
    })
})

MongoClient.connect('mongodb://127.0.0.1:27017', (err, database) => {

    if (err) {

        return console.log(err)

    } else {

        db = database.db("trainProjectWork")

        app.listen(3000, function () {
            console.log('listening on http://localhost:3000/')
        })
    }
})   