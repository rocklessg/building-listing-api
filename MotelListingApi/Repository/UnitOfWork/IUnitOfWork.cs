using MotelListingApi.Data;
using MotelListingApi.Repository.GenericRepository;
using System;
using System.Threading.Tasks;

namespace MotelListingApi.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();

    }
}
