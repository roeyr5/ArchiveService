using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchiveData.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace ArchiveData.Services
{
    public class ArchiveService
    {
        private readonly IMongoDatabase database;
        public ArchiveService(IMongoClient iMongoClient , IConfiguration iConfiguration)
        {
            string databaseName = iConfiguration.GetValue<string>("MongoDbSettings:DatabaseName");
            database = iMongoClient.GetDatabase(databaseName);
        }

        public async Task<List<ArchiveDataDto>> GetArchiveData(ArchiveRequestDto archiveDto)
        {
            List<ArchiveDataDto> archivedUAVsDataList = new();
            archiveDto.StartDate = TimeZoneInfo.ConvertTime(archiveDto.StartDate, TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time"));
            foreach (int uavNumber in archiveDto.UavNumbers)
            {

                var collection = database.GetCollection<BsonDocument>(uavNumber.ToString());

                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Gte("TimeStamp", archiveDto.StartDate),
                    Builders<BsonDocument>.Filter.Lte("TimeStamp", archiveDto.EndDate),
                    Builders<BsonDocument>.Filter.Eq("Communication", archiveDto.Communication)
                );

                int skipCount = (archiveDto.PageNumber - 1) * archiveDto.PageSize;
                int limitCount = archiveDto.PageSize;

                var result = await collection.Find(filter).Skip(skipCount).Limit(limitCount).ToListAsync();

                var archiveDataPackets = result.Select(doc => new ArchiveDataPacket
                {
                    Value = doc["Data"].AsBsonDocument.Contains(archiveDto.ParameterName) ?
                   doc["Data"].AsBsonDocument[archiveDto.ParameterName].ToString() : null,
                    DateTime = doc["TimeStamp"].ToUniversalTime(),
                    UavNumber = uavNumber

                }).ToList();

                ArchiveDataDto uavArchivedData = new()
                {
                    ArchiveDataPackets = archiveDataPackets,
                    UavNumber = uavNumber,
                    Communication = archiveDto.Communication
                };

                archivedUAVsDataList.Add(uavArchivedData);
            }

            return archivedUAVsDataList;
        
        }

        public async Task<List<string>> GetAllUavs()
        {
            var collectionsCursor = await database.ListCollectionNamesAsync();
            List<string> collectionNames = await collectionsCursor.ToListAsync();
            return collectionNames;
        }
    }
}
