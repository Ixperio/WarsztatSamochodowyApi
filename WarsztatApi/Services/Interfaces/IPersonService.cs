using WarsztatApi.Dto;

namespace WarsztatApi.Services.Interfaces
{
    public interface IPersonService
    {
        //getters
        public List<UserDto> getListOfUsers();

        public UserDto getPersonById(int id);

        public UserDto getUserByTrustString(string trustString);

        public UserDtoLogin getLoggedUser(string login, string pass);

        public TrustString getTrustStringByUser(int id);

        public UserTypeDto? getUserTypeByTrustString(string trusteString);

        public int? getPersonIdByTrustString(string trustString);

        public List<int>? getAllAdminsId();

        public List<int>? getAllManagersId();

        //adders
        public bool addNewUser(UserDtoRegister user);

        //updates

        public bool updateUserName(UserDtoUpdateName user);

        public bool updateUserSurname(UserDtoUpdateSurname user);

        public bool updateUserEmail(UserDtoUpdateEmail user);

        public bool updateUserPassword(UserDtoUpdatePassword user);

        public bool updateUserPhone(UserDtoUpdatePhone user);

        public bool updateUserBirthday(UserDtoUpdateBirthday user);

        public bool updateUserPost(UserDtoUpdatePost user);

        public bool updateUserAdress(UserDtoUpdateAdress user);

        public bool updateUserCity(UserDtoUpdateCity user);

        //deletes

        public bool deleteUser(UserDtoDelete user);

    }
}
