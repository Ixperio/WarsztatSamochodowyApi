using WarsztatApi.Dto;

namespace WarsztatApi.Services.Interfaces
{
    public interface IUserTypeService
    {
        public UserTypeDto? GetUserTypeById(int id);

        public UserTypeDto? GetUserTypeByName(string name);

        public bool EditUserType(int id, string newName);

        public bool AddNewUserType(UserTypeDto userType);

    }
}
