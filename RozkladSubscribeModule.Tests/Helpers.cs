﻿using System.Collections.Generic;
using RozkladSubscribeModuleClient.Entities;

namespace RozkladSubscribeModule.Tests
{
    internal static class Helpers
    {
        internal static List<SubscribedUser> CreateUsers(
            int count,
            int groupExternalId,
            string facultyShortName) {
            List<SubscribedUser> resultList = new List<SubscribedUser>(count);

            for (int i = 0; i < count; i++) {
                resultList.Add(new SubscribedUser {
                    FacultyShortName = facultyShortName,
                    GroupExternalId = groupExternalId,
                    TelegramId = int.Parse($"{i}{i + i}{i * i}{i}")
                });
            }

            return resultList;
        }
    }
}
