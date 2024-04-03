using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Movies.Api;
using System.Text.Json;

await new DataSeeder().ImportDataAsync();

//var newMovie1 = new Movie1
//{
//    Id = Guid.NewGuid(),
//    Title = "21 Jump Street",
//    AgeRestriction = 18,
//    ReleaseYear = 2012,
//    RottenTomatoesPercentage = 85
//};

//var asJson1 = JsonSerializer.Serialize(newMovie1);
//var attributeMap1 = Document.FromJson(asJson1).ToAttributeMap();

//var newMovie2 = new Movie2
//{
//    Id = Guid.NewGuid(),
//    Title = "21 Jump Street",
//    AgeRestriction = 18,
//    ReleaseYear = 2012,
//    RottenTomatoesPercentage = 85
//};

//var asJson2 = JsonSerializer.Serialize(newMovie2);
//var attributeMap2 = Document.FromJson(asJson2).ToAttributeMap();

//var transactionRequest = new TransactWriteItemsRequest
//{
//    TransactItems = new List<TransactWriteItem>
//    {
//        new TransactWriteItem
//        {
//            Put = new Put
//            {
//                TableName = "movies-year-title",
//                Item = attributeMap1
//            }
//        },
//        new TransactWriteItem
//        {
//            Put = new Put
//            {
//                TableName = "movies-title-rotten",
//                Item = attributeMap2
//            }
//        }
//    }
//};

//var dynamoDb = new AmazonDynamoDBClient();

//var response = await dynamoDb.TransactWriteItemsAsync(transactionRequest);





