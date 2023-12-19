using DB.Entities;
using Microsoft.Identity.Client;

namespace WarsztatApi.Repo.Interfaces
{
    public interface IUserTypeRepository
    {
        //getters
        public UserType getById(int id);

        public UserType getByName(string name);

        //setters

        public bool AddNew(string newUserType);

        public bool EditById(int IdOfEditingUserTypeRecord, string NewName);

    }
}
