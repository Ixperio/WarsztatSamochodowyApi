using WarsztatApi.Dto;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Security.Interfaces;
using WarsztatApi.Services.Interfaces;

namespace WarsztatApi.Services
{
    public class UserTypeService : IUserTypeService
    {

        public readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            this._userTypeRepository = userTypeRepository;
        }

        public UserTypeDto? GetUserTypeById(int id)
        {
            if (id > 0)
            {
                var userType = _userTypeRepository.getById(id);
                if(userType != null)
                {
                    return new UserTypeDto() { Nazwa = userType.Name };
                }
                else
                {
                    return null;
                }
               
            }
            else
            {
                return null;
            }
        }

        public UserTypeDto? GetUserTypeByName(string name)
        {
            var userType = _userTypeRepository.getByName(name);
            if (userType != null)
            {
                return new UserTypeDto() { Nazwa = userType.Name };
            }
            else
            {
                return null;
            }
        }

        public bool EditUserType(int id,string newName)
        {
            var type = _userTypeRepository.EditById(id,newName);
            if (type)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AddNewUserType(UserTypeDto userType)
        {
            return _userTypeRepository.AddNew(userType.Nazwa);
        }

    }
}
