using System.Globalization;
using WarsztatApi.Dto;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Services.Interfaces;
using WarsztatApi.Security.Interfaces;
using DB.Entities;

namespace WarsztatApi.Services
{
    public class PersonService : IPersonService
    {
        public readonly IPersonRepository _personRepository;
        public readonly IUserTypeRepository _userTypeRepository;
        public readonly ISecurity _security;

        public PersonService(IPersonRepository personRepository, ISecurity security, IUserTypeRepository userTypeRepository)
        {
            this._personRepository = personRepository;
            this._security = security; 
            this._userTypeRepository = userTypeRepository;
        }
        //getters
        public List<UserDto> getListOfUsers()
        {
            var users = new List<UserDto>();

            var usersRepo = _personRepository.getPersons();

            foreach (var user in usersRepo)
            {
                users.Add(new UserDto()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Phone = user.Phone,
                    Birthday = user.Birthday.ToString(),
                    Adress = user.Adress,
                    City = user.City,
                    Email = user.Email,
                    PostCode = user.PostCode
                });
            }
            return users;
        }

        public UserDto getPersonById(int id)
        {
            var userDb = _personRepository.getPersonById(id);
            if(userDb != null)
            {
                var user = new UserDto()
                {
                    Name = userDb.Name,
                    Surname = userDb.Surname,
                    Phone = userDb.Phone,
                    Birthday = userDb.Birthday.ToString(),
                    Adress = userDb.Adress,
                    City = userDb.City,
                    Email = userDb.Email,
                    PostCode = userDb.PostCode
                };

                return user;
            }
            else
            {
                return null;
            }
           
        }

        public UserDto getUserByTrustString(string trustString)
        {

            var getUser = _personRepository.getPersonByTrustString(trustString);

            if (getUser != null)
            {
                var user = new UserDto()
                {
                    Name = getUser.Name,
                    Surname = getUser.Surname,
                    Phone = getUser.Phone,
                    Adress = getUser.Adress,
                    City = getUser.City,
                    Email = getUser.Email,
                    PostCode = getUser.PostCode,
                    Birthday = new DateTime(getUser.Birthday.Year, getUser.Birthday.Month, getUser.Birthday.Day).ToString().Substring(0, 10)
                    
                };

                return user;
            }
            else
            {
                return null;
            }
        }

        public TrustString? getTrustStringByUser(int id)
        {
            var trustString = _personRepository.getTrustStringByUserId(id);
            if (!string.IsNullOrEmpty(trustString))
            {
                return new TrustString() { trustString = trustString};
            }
            else
            {
                return null;
            }

            
        }

        public UserDtoLogin getLoggedUser(string login, string pass)
        {
            var getUser = _personRepository.getPersonByLoginAndPassword(login, pass);

            if(getUser != null)
            {

               return new UserDtoLogin() { Id = getUser.Value};

            }
            else
            {
                return null;
            }

        }

        public UserTypeDto? getUserTypeByTrustString(string trustString)
        {
            var getUser = _personRepository.getPersonByTrustString(trustString);

            if (getUser != null)
            {
               var userTP = _userTypeRepository.getById(getUser.rodzajUzytkownika);
                if (userTP != null)
                {
                    return new UserTypeDto() { Nazwa = userTP.Name };
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

        public int? getPersonIdByTrustString(string trustString)
        {
            var getUser = _personRepository.getPersonByTrustString(trustString);
            if(getUser != null)
            {
                return getUser.Id;
            }
            else
            {
                return null;
            }
        }

        public List<int>? getAllAdminsId()
        {
            return _personRepository.getAllUsersIdByUserTypeId(4);
        }

        public List<int>? getAllManagersId()
        {
            return _personRepository.getAllUsersIdByUserTypeId(3);
        }

        //setters
        public bool addNewUser(UserDtoRegister user)
        {
            if(user != null)
            {
                if(user.Email == user.EmailConfirm && user.Password == user.PasswordConfirm && user.Terms == true)
                {
                    return _personRepository.addNewPerson(user);
                }
            }

            return false;
        }

        //edits

        public bool updateUserName(UserDtoUpdateName user)
        {
            return _personRepository.updateUserName(user);
        }

        public bool updateUserSurname(UserDtoUpdateSurname user)
        {
            return _personRepository.updateUserSurname(user);
        }

        public bool updateUserEmail(UserDtoUpdateEmail user)
        {
            return _personRepository.updateUserEmail(user);
        }

        public bool updateUserPassword(UserDtoUpdatePassword user)
        {
            return _personRepository.updateUserPassword(user);
        }

        public bool updateUserPhone(UserDtoUpdatePhone user)
        {
            return _personRepository.updateUserPhone(user);
        }

        public bool updateUserBirthday(UserDtoUpdateBirthday user)
        {
            return _personRepository.updateUserBirthday(user);
        }

        public bool updateUserPost(UserDtoUpdatePost user)
        {
            return _personRepository.updateUserPost(user);
        }

        public bool updateUserAdress(UserDtoUpdateAdress user)
        {
            return _personRepository.updateUserAdress(user);
        }

        public bool updateUserCity(UserDtoUpdateCity user)
        {
            return _personRepository.updateUserCity(user);
        }

        //deleters

        public bool deleteUser(UserDtoDelete user)
        {
            return _personRepository.deleteUser(user);
        }


    }
}
