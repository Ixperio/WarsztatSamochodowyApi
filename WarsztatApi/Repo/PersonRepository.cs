using DB;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WarsztatApi.Dto;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Security.Interfaces;

namespace WarsztatApi.Repo
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyDbContext _database;
        private readonly ISecurity _security;
        public PersonRepository(MyDbContext database, ISecurity security)
        {
            _database = database;
            _security = security;
        }
        //getters
        public List<Person> getPersons()
        {

                var persons = _database.Persons.ToList();

                if (persons != null)
                {
                    var users = new List<Person>();

                    foreach (var person in persons)
                    {

                        users.Add(new Person()
                        {
                            Id = person.Id, 
                            Name = person.Name,
                            Surname = person.Surname,
                            Birthday = person.Birthday,
                            Phone = person.Phone,
                            Email = person.Email,
                            PostCode = person.PostCode,
                            City = person.City,
                            Adress = person.Adress,
                            Password = person.Password,
                            CreationDate = person.CreationDate
                        });

                    }
                    return users;
                }
                else
                {
                    return null;
                }

        }

        public Person? getPersonById(int id)
        {
           var user = _database.Persons.FirstOrDefault(x => x.Id == id && x.isDeleted == false);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public Person? getPersonByEmail(string email)
        {
            var user = _database.Persons.FirstOrDefault(x => x.Email == email && x.isDeleted == false);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public Person? getPersonByTrustString(string trustString)
        {
                var user = _database.Persons.FirstOrDefault(x => x.trustString == trustString && x.isDeleted == false);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
        }

        public string? getTrustStringByUserId(int id)
        {
                var user = this.getPersonById(id);

                if (user != null)
                {
                    return user.trustString;
                }
                else
                {
                    return null;
                }  
        }

        public int? getPersonByLoginAndPassword(string login,string pass)
        {
            var user = _database.Persons.FirstOrDefault(x => x.Email == login && x.isDeleted == false);

            if (user != null)
            {
                if (_security.CompareSHA256(pass, user.Password) == true)
                {
                    bool val = true;
                    int counter = 0;

                    do
                    {
                        user.trustString = _security.GetTrustString();

                        if (_database.Persons.FirstOrDefault(x => x.trustString == user.trustString) == null)
                        {
                            _database.Update(user);
                            _database.SaveChanges();
                            val = false;
                        }
                        else
                        {
                            counter++;
                        }

                    } while (val && (counter < 10));

                    if (counter >= 10)
                    {
                        return null;
                    }
                    else
                    {
                        return user.Id;

                    }
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

        public List<int>? getAllUsersIdByUserTypeId(int id)
        {

            return _database.Persons.Where(x => x.rodzajUzytkownika == id).Select(x => x.Id).ToList();

        }
        //adders
        public bool addNewPerson(UserDtoRegister user)
        {
            if(getPersonByEmail(user.Email) == null)
            {

                Person person = new Person()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Password = _security.CalculateSHA256(user.Password),
                    Adress = "xxx",
                    Phone = user.Phone,
                    Birthday = DateTime.Parse(user.Birthday),
                    City = "xxx",
                    PostCode = "xx-xxx",
                    trustString = "",
                    rodzajUzytkownika = 1,
                    CreationDate = DateTime.Now

                };

                _database.Add(person);
                _database.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }
        }

        //updates
        public bool updateUserName(UserDtoUpdateName user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {

                userInDb.Name = user.Name;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool updateUserSurname(UserDtoUpdateSurname user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {

                userInDb.Surname = user.Surname;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool updateUserEmail(UserDtoUpdateEmail user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null && (user.Email == user.EmailConfirm))
            {

                userInDb.Email = user.Email;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserPassword(UserDtoUpdatePassword user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null && (user.Password == user.PasswordConfirm) && _security.CompareSHA256(user.ActualPassword, userInDb.Password))
            {
                userInDb.Password = _security.CalculateSHA256(user.Password);
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserPhone(UserDtoUpdatePhone user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {

                userInDb.Phone = user.Phone;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserBirthday(UserDtoUpdateBirthday user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {
                DateTime date = DateTime.Parse(user.Birthday);

                userInDb.Birthday = date;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserPost(UserDtoUpdatePost user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {
      
                userInDb.PostCode = user.Post;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserAdress(UserDtoUpdateAdress user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {

                userInDb.Adress = user.Adress;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserCity(UserDtoUpdateCity user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {

                userInDb.City = user.City;
                _database.Update(userInDb);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //deletes

        public bool deleteUser(UserDtoDelete user)
        {
            var userInDb = getPersonByTrustString(user.trustString);
            if (userInDb != null)
            {
                if(_security.CompareSHA256(user.Password, userInDb.Password))
                {

                    userInDb.isDeleted = true;
                    _database.Update(userInDb);
                    _database.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
