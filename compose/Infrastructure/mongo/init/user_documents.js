db = new Mongo().getDB("repertoireSearchEngineDB");
db.createCollection("users");

db.getCollection("users").insert([
    {
        "_id": ObjectId("641202d16bcff5847905285f"),
        "username": "username",
        "email": "username@test.com",
        "firstName": "firstName",
        "lastName": "lastName",
        "createdDate": new Date(),
    }
]);