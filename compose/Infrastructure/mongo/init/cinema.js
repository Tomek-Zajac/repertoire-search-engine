db = new Mongo().getDB("repertoireSearchEngineDB");
db.createCollection("cinemas");

db.getCollection("cinemas").insertMany([{
    "_id": ObjectId("64207fa0283a793a0f059ef4"),
    "cinemaName": "ABC Cinema",
    "address": "123 Main Street",
    "city": "New York",
    "state": "NY",
    "zipCode": "10001",
    "repertoire": [
        {
            "_id": ObjectId("64207fa0283a793a0f059ef5"),
            "movieTitle": "Avengers: Endgame",
            "showtimes": [
                "2023-03-27 13:00:00",
                "2023-03-27 16:00:00",
                "2023-03-27 19:00:00"
            ],
            "imageUrl": "https://static.posters.cz/image/1300/plakaty/avengers-endgame-journey-s-end-i122136.jpg"
        },
        {
            "_id": ObjectId("64207fa0283a793a0f059ef7"),
            "movieTitle": "Jurassic World",
            "showtimes": [
                "2023-03-27 14:00:00",
                "2023-03-27 17:00:00",
                "2023-03-27 20:00:00"
            ],
            "imageUrl": "https://sm.ign.com/ign_pl/screenshot/default/jurassic-world_pjs9.jpg"
        }
    ]
},
{
    "_id": ObjectId("64207fa0283a793a0f059ef8"),
    "cinemaName": "XYZ Cinema",
    "address": "456 Elm Street",
    "city": "Los Angeles",
    "state": "CA",
    "zipCode": "90001",
    "repertoire": [
        {
            "_id": ObjectId("64207fa0283a793a0f059e11"),
            "movieTitle": "The Dark Knight",
            "showtimes": [
                "2023-03-27 12:00:00",
                "2023-03-27 15:00:00",
                "2023-03-27 18:00:00"
            ],
            "imageUrl": "https://www.example.com/images/dark-knight.jpg"
        },
        {
            "_id": ObjectId("64207fa0283a793a0f059e12"),
            "movieTitle": "Jurassic World",
            "showtimes": [
                "2023-03-27 14:00:00",
                "2023-03-27 17:00:00",
                "2023-03-27 20:00:00"
            ],
            "imageUrl": "https://www.example.com/images/jurassic-world.jpg"
        }
    ]
}
]);