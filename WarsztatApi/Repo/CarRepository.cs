using DB;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;
using WarsztatApi.Dto;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Security.Interfaces;

namespace WarsztatApi.Repo
{
    public class CarRepository : ICarRepository
    {
        private readonly MyDbContext _database;
        private readonly ISecurity _security;

        public CarRepository(MyDbContext database, ISecurity security)
        {
            this._database = database;
            this._security = security;
        }

        public bool test()
        {
            return true;
        }

        public Samochod? getCarByVinNumber(string vinNumber)
        {
            var car = _database.Car.FirstOrDefault(x => x.VIN == vinNumber && x.isDeleted != true);
            if(car != null)
            {
                return car;
            }
            else
            {
                return null;
            }
           
        }

        public List<Samochod>? getUserCars(int id)
        {
           var data = _database.Car.Where(x => x.WlascicielId == id && x.isDeleted != true).ToList();

            if(data.Count > 0)
            {
                return data;
            }
            else
            {
                return null;
            }

        }

        public Paliwo? getFuelById(int id)
        {

            return _database.Fuel.FirstOrDefault(x => x.Id == id);

        }

        public ModelSamochodu? getCarModelById(int id)
        {
            return _database.CarModels.FirstOrDefault(x => x.Id == id);
        }

        public Marka? getCarBrandById(int id)
        {
            return _database.Brand.FirstOrDefault(x => x.Id == id);
        }
        public WersjeNadwozia? getCarBodyById(int id)
        {
            return _database.CarModelType.FirstOrDefault(x => x.Id == id);
        }
        public List<Marka>? getCarBrandByName(string name)
        {
            return _database.Brand.Where(x => x.Name == name).ToList();
        }

        public List<WersjeNadwozia>? getCarBodyWersionByName(string name)
        {
            return _database.CarModelType.Where(x => x.Name == name).ToList();
        }

        public List<ModelSamochodu>? getCarModelByName(string name)
        {
            return _database.CarModels.Where(x => x.Name == name).ToList();
        }

        public List<Marka>? getBrands()
        {
            return _database.Brand.Where(x => x.Id > 0).ToList();
        }

        public List<WersjeNadwozia>? getBody()
        {
            return _database.CarModelType.Where(x => x.Id > 0).ToList();
        }

        public List<ModelSamochodu>? getModel()
        {
            return _database.CarModels.Where(x => x.Id > 0).ToList();
        }

        public List<Paliwo>? getFuelTypes()
        {
            return _database.Fuel.Where(x => x.Id > 0).ToList();
        }

        //adders

        public bool AddCar(int userId, SamochodDtoAdd car)
        {
            var newCar = new Samochod()
            {
                VIN = car.VIN,
                Nazwa = car.Nazwa,
                ModelSamochoduId = car.modelSamochdouId,
                pojemnoscSkokowa = car.pojemnoscSkokowa,
                nr_rejestracyjny = car.nr_rejestracyjny,
                przebieg = car.przebieg,
                rokProdukcji = car.rokProdukcji,
                rodzajPaliwaId = car.rodzajPaliwaId,
                WlascicielId = userId,
                isDeleted = false
            };

            _database.Car.Add(newCar);
            _database.SaveChanges();

            return true;
        }
    
        public bool AddCarBrand(int userId, MarkaDtoAdd brand)
        {
            var newBrand = new Marka()
            {
                Name = brand.Name,
                PersonAdderId = userId
            };
            _database.Brand.Add(newBrand);
            _database.SaveChanges();

            return true;
        }

        public bool AddCarModel(int userId, ModelSamochoduDtoAdd model)
        {
            var newModel = new ModelSamochodu()
            {
                Name = model.Name,
                WersjaId = model.WersjaNadwoziaId,
                MarkaId = model.MarkaId,
                PersonAdderId=userId
            };
            _database.CarModels.Add(newModel);
            _database.SaveChanges();

            return true;
        }

        public bool AddCarBody(int userId, WersjeNadwoziaDtoAdd model)
        {
            var newBody = new WersjeNadwozia()
            {
                Name = model.Name,
                PersonAdderId = userId
            };
            _database.CarModelType.Add(newBody);
            _database.SaveChanges();

            return true;
        }

        public bool DeleteCar(int userId, int carId) {

           var car = _database.Car.FirstOrDefault(x => x.WlascicielId == userId && x.Id == carId);
            if(car != null)
            {
                car.isDeleted = true;

                _database.Car.Update(car);
                _database.SaveChanges();

                return true;
            }
            return false;
           
        }


    }
}
