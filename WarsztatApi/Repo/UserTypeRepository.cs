using DB;
using DB.Entities;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using WarsztatApi.Dto;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Security.Interfaces;

namespace WarsztatApi.Repo
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly MyDbContext _database;
        public UserTypeRepository(MyDbContext database)
        {
            _database = database; 
        }

        //pobieranie danych z bazy przy uzyciu identyfikatora 
        public UserType getById(int id)
        {
            return _database.UserTypes.FirstOrDefault(ut=> ut.Id == id);
        }
        //pobieranie danych z bazy przy uzyciu nazwy typu
        public UserType getByName(string name)
        {
            return _database.UserTypes.FirstOrDefault(ut => ut.Name == name);
        }

        //setters

        //tworzenie nowego typu
        public bool AddNew(string newUserType)
        {
            if(this.getByName(newUserType) == null)
            {
                var newUT = new UserType() { Name = newUserType };
                _database.UserTypes.Add(newUT);
                _database.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }   
        }

        public bool EditById(int IdOfEditingUserTypeRecord, string NewName)
        {
            var editable = this.getById(IdOfEditingUserTypeRecord);
            if (editable != null)
            {
                editable.Name = NewName;
                _database.Update(editable);
                _database.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
