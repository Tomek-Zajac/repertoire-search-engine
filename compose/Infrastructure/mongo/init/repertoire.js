db = new Mongo().getDB("repertoireSearchEngineDB");
db.createCollection("repertoire");

db.getCollection("repertoire").insertMany([{
    "movieTitle": "The Shawshank Redemption",
    "genre": "Drama",
    "rating": 9.3,
    "showtimes": [
        "2023-03-25T14:00:00",
        "2023-03-25T18:00:00",
        "2023-03-25T22:00:00",
        "2023-03-26T14:00:00",
        "2023-03-26T18:00:00",
        "2023-03-26T22:00:00",
        "2023-03-27T14:00:00",
        "2023-03-27T18:00:00",
        "2023-03-27T22:00:00"]
},
{
    "movieTitle": "The Godfather",
    "genre": "Crime",
    "rating": 9.2,
    "showtimes": [
        "2023-03-25T15:00:00",
        "2023-03-25T19:00:00",
        "2023-03-25T23:00:00",
        "2023-03-26T15:00:00",
        "2023-03-26T19:00:00",
        "2023-03-26T23:00:00",
        "2023-03-27T15:00:00",
        "2023-03-27T19:00:00",
        "2023-03-27T23:00:00"
    ]
},
{
    "movieTitle": "The Dark Knight",
    "genre": "Action",
    "rating": 9.0,
    "showtimes": [
        "2023-03-25T16:00:00",
        "2023-03-25T20:00:00",
        "2023-03-26T16:00:00",
        "2023-03-26T20:00:00",
        "2023-03-27T16:00:00",
        "2023-03-27T20:00:00"
    ]
}
]);
