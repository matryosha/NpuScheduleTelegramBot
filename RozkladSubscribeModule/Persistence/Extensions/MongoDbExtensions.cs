﻿using System.Collections.Generic;
using MongoDB.Bson;
using RozkladSubscribeModule.Entities;
using RozkladSubscribeModule.Infrastructure;

namespace RozkladSubscribeModule.Persistence.Extensions
{
    internal static class MongoDbExtensions
    {
        public static SubscribedUser ToSubscribedUser(this MongoSubscribedUser mongoSubscribedUser)
        {
            return mongoSubscribedUser.SubscribedUser;
        }

        public static ICollection<SubscribedUser> ToSubscribedUsers(
            this ICollection<MongoSubscribedUser> mongoSubscribedUsers)
        {
            var result = 
                new List<SubscribedUser>(mongoSubscribedUsers.Count);

            foreach (var mongoSubscribedUser in mongoSubscribedUsers)
            {
                result.Add(mongoSubscribedUser.SubscribedUser);
            }

            return result;
        }

        public static MongoSubscribedUser ToMongoSubscribedUser(this SubscribedUser subscribedUser) {
            return new MongoSubscribedUser
            {
                Id = Base64Coder.Encode(subscribedUser.ToString()),
                SubscribedUser = subscribedUser
            };
        }

        public static ICollection<MongoSubscribedUser> ToMongoSubscribedUsers(
            this ICollection<SubscribedUser> subscribedUsers) {
            var result =
                new List<MongoSubscribedUser>(subscribedUsers.Count);

            foreach (var subscribedUser in subscribedUsers) {
                result.Add(new MongoSubscribedUser
                {
                    Id = Base64Coder.Encode(subscribedUser.ToString()),
                    SubscribedUser = subscribedUser
                });
            }

            return result;
        }
    }
}
