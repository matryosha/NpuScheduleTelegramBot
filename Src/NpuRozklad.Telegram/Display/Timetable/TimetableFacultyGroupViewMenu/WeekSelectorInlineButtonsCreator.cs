using System;
using NpuRozklad.Core.Entities;
using NpuRozklad.Telegram.Display.Common.Controls;
using NpuRozklad.Telegram.Display.Common.Text;
using NpuRozklad.Telegram.Services.Interfaces;
using Telegram.Bot.Types.ReplyMarkups;
using static NpuRozklad.Telegram.Helpers.TimetableFacultyGroupViewMenuCallbackDataSerializer;

namespace NpuRozklad.Telegram.Display.Timetable.TimetableFacultyGroupViewMenu
{
    public class WeekSelectorInlineButtonsCreator
    {
        private readonly ICurrentUserLocalizationService _currentUserLocalizationService;
        private readonly InlineKeyboardButtonsCreator _inlineKeyboardButtonsCreator;

        public WeekSelectorInlineButtonsCreator(
            ICurrentUserLocalizationService currentUserLocalizationService,
            InlineKeyboardButtonsCreator inlineKeyboardButtonsCreator)
        {
            _currentUserLocalizationService = currentUserLocalizationService;
            _inlineKeyboardButtonsCreator = inlineKeyboardButtonsCreator;
        }

        public InlineKeyboardButton[] Create(WeekSelectorInlineButtonsCreatorOptions options)
        {
            var isNextWeekActive = options.IsNextWeekActive;
            var activeDayOfWeek = (int) options.ActiveDayOfWeek;
            var facultyGroup = options.FacultyGroup;
            var buttonsText = GetButtonsText();

            var buttons = _inlineKeyboardButtonsCreator.Create( o =>
            {
                o.ItemsNumber = 2;
                o.ButtonTextFunc = i => buttonsText[i];
                o.CallbackDataFunc = i =>
                    ToCallbackData(i == 0 ? false : true, (DayOfWeek) activeDayOfWeek, facultyGroup);
            })[0];

            var buttonIndexToChange = isNextWeekActive ? 1 : 0;
            var button = buttons[buttonIndexToChange];
            button.Text = $"{TextDecoration.ActiveMark} {button.Text}";

            return buttons;
        }

        private string[] GetButtonsText()
        {
            var result = new string[2];

            result[0] = _currentUserLocalizationService["this-week"];
            result[1] = _currentUserLocalizationService["next-week"];

            return result;
        }
    }

    public class WeekSelectorInlineButtonsCreatorOptions
    {
        public bool IsNextWeekActive { get; set; }
        public DayOfWeek ActiveDayOfWeek { get; set; }
        public Group FacultyGroup { get; set; }
    }
}