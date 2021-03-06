using System.Collections.Generic;
using System.Threading.Tasks;
using NpuRozklad.Core.Entities;

namespace NpuRozklad.LessonsProvider.Holders.Interfaces
{
    internal interface IGroupsHolder
    {
        Task<ICollection<Group>> GetFacultiesGroups();
    }
}