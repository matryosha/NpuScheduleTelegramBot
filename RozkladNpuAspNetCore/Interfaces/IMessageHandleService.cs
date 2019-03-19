﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace RozkladNpuAspNetCore.Interfaces
{
    public interface IMessageHandleService
    {
        Task HandleMessage(Message message);
        Task ShowMainMenu();
        Task ShowScheduleMenu();
    }
}
