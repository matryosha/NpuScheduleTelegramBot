using System;
using System.Linq;
using System.Threading.Tasks;
using NpuRozklad.Core.Entities;
using NpuRozklad.Core.Interfaces;
using NpuRozklad.Telegram.BotActions;
using NpuRozklad.Telegram.Services.Interfaces;

namespace NpuRozklad.Telegram.Handlers.CallbackQueryHandlers.SpecificHandlers
{
    public class ShowTimetableFacultyGroupViewMenuCallbackHandler : SpecificHandlerBase
    {
        private readonly ITelegramBotActions _botActions;
        private readonly IFacultiesProvider _facultiesProvider;
        private readonly IFacultyGroupsProvider _facultyGroupsProvider;

        private CallbackQueryData _callbackQueryData;

        private Faculty _faculty;
        private Group _facultyGroup;
        private DayOfWeek _dayOfWeek;
        private bool _isNextWeek;
        private string _facultyTypeId;
        private string _facultyGroupTypeId;

        public ShowTimetableFacultyGroupViewMenuCallbackHandler(ITelegramBotActions botActions,
            IFacultiesProvider facultiesProvider,
            IFacultyGroupsProvider facultyGroupsProvider,
            ITelegramBotService telegramBotService)
            : base(telegramBotService)
        {
            _botActions = botActions;
            _facultiesProvider = facultiesProvider;
            _facultyGroupsProvider = facultyGroupsProvider;
        }

        protected override async Task HandleImplementation(CallbackQueryData callbackQueryData)
        {
            _callbackQueryData = callbackQueryData;
            ProcessCallbackQueryData();
            await GetFaculty();
            await GetFacultyGroup();


            var actionOptions = new ShowTimetableFacultyGroupViewMenuOptions
            {
                FacultyGroup = _facultyGroup,
                DayOfWeek = _dayOfWeek,
                IsNextWeekSelected = _isNextWeek
            };

            await _botActions.ShowTimetableFacultyGroupViewMenu(actionOptions);
        }

        private async Task GetFacultyGroup()
        {
            var facultyGroupTypeId = _facultyGroupTypeId;
            var facultyGroups = await _facultyGroupsProvider.GetFacultyGroups(_faculty);
            _facultyGroup = facultyGroups.FirstOrDefault(g => g.TypeId == facultyGroupTypeId);
        }

        private void ProcessCallbackQueryData()
        {
            var values = _callbackQueryData.Values;

            _isNextWeek = values[0] == "1";
            _dayOfWeek = (DayOfWeek) Convert.ToInt32(values[1]);
            _facultyGroupTypeId = values[2];
            _facultyTypeId = values[3];
        }

        private async Task GetFaculty()
        {
            var faculties = await _facultiesProvider.GetFaculties();
            var facultyTypeId = _facultyTypeId;
            _faculty = faculties.FirstOrDefault(f => f.TypeId == facultyTypeId);
        }
    }
}