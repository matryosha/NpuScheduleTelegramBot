using System.Collections.Generic;
using System.Threading.Tasks;
using NpuRozklad.Core.Entities;

namespace NpuRozklad.Core.Interfaces
{
    public interface IFacultiesProvider
    {
        Task<ICollection<Faculty>> GetFaculties();
    }
}