using GamblingLicenseeManager.Models;
using Newtonsoft.Json;
using System.Xml;

namespace GamblingLicenseeManager.Repositories
{

    // Repositories/LicenseeRepository.cs
    public class LicenseeRepository : ILicenseeRepository
    {
        private readonly string _filePath = "Data/Accounts.json";
        private List<Licensee> _licensees;

        public LicenseeRepository()
        {
            // Load data from JSON file
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _licensees = JsonConvert.DeserializeObject<List<Licensee>>(json);
            }
            else
            {
                _licensees = new List<Licensee>();
            }
        }

        public IEnumerable<Licensee> GetAll() => _licensees;

        public Licensee GetById(int id) => _licensees.FirstOrDefault(l => l.Id == id);

        public void Add(Licensee licensee)
        {
            _licensees.Add(licensee);
            SaveToFile();
        }

        public void Update(Licensee licensee)
        {
            var index = _licensees.FindIndex(l => l.Id == licensee.Id);
            if (index != -1)
            {
                _licensees[index] = licensee;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var licensee = GetById(id);
            if (licensee != null)
            {
                _licensees.Remove(licensee);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var json = JsonConvert.SerializeObject(_licensees, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }

}
