
using DB.Entities;
using WarsztatApi.Dto;

namespace WarsztatApi.Repo.Interfaces
{
    public interface IPersonRepository
    {

        public List<Person>? getPersons();

        public Person? getPersonById(int id);

        public Person? getPersonByTrustString(string trustString);

        public int? getPersonByLoginAndPassword(string login, string pass);

        public string? getTrustStringByUserId(int id);

        public bool addNewPerson(UserDtoRegister user);

        public List<int>? getAllUsersIdByUserTypeId(int id);

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
