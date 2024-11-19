using GamblingLicenseeManager.Models;

namespace GamblingLicenseeManager.Repositories
{
    // Repositories/ILicenseeRepository.cs
    public interface ILicenseeRepository
    {
        IEnumerable<Licensee> GetAll();
        Licensee GetById(int id);
        void Add(Licensee licensee);
        void Update(Licensee licensee);
        void Delete(int id);
    }
}
