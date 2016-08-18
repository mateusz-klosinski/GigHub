using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IUserRepository Users { get; }
        IGenreRepository Genres { get; }
        void Complete();
    }
}