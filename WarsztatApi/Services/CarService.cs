using WarsztatApi.Dto;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Services.Interfaces;
using DB.Entities;
using WarsztatApi.Repo;

namespace WarsztatApi.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IPersonService _personService;
        public CarService(ICarRepository carRepository, IPersonService personService)
        {
            this._carRepository = carRepository;
            this._personService = personService;
        }
        //tests
        public bool test()
        {
            return true;
        }

        public bool testRepo()
        {
            return _carRepository.test();
        }
        //getters
        public List<SamochodDtoView>? getCarByUserId(int id)
        {
            var cars = _carRepository.getUserCars(id);
            var samochody = new List<SamochodDtoView>();
            if (cars != null)
            {
                foreach (var car in cars)
                {
                    var carDto = new SamochodDtoView()
                    {
                        Id = car.Id,
                        VIN = car.VIN,
                        Nazwa = car.Nazwa,
                        modelSamochodu = new ModelSamochoduDto()
                        {

                            Name = _carRepository.getCarModelById(car.ModelSamochoduId).Name,
                            Marka = new MarkaDto()
                            {
                                Name = _carRepository.getCarBrandById(_carRepository.getCarModelById(car.ModelSamochoduId).MarkaId).Name
                            },
                            WersjaNadwozia = new WersjeNadwoziaDto()
                            {
                                Name = _carRepository.getCarBodyById(_carRepository.getCarModelById(car.ModelSamochoduId).WersjaId).Name
                            }
                        },
                        rodzajPaliwa = new PaliwoDto()
                        {
                            Name = _carRepository.getFuelById(car.rodzajPaliwaId).Name
                        },
                        rokProdukcji = car.rokProdukcji,
                        pojemnoscSkokowa = car.pojemnoscSkokowa,
                        przebieg = car.przebieg,
                        nr_rejestracyjny = car.nr_rejestracyjny

                    };

                    samochody.Add(carDto);
                }
            }
            else
            {
                return null;
            }

            return samochody;
        }

        public SamochodDto? getCarByVinNumber(string vinNumber)
        {
            var car = _carRepository.getCarByVinNumber(vinNumber);

            if (car != null)
            {
                var carDto = new SamochodDto()
                {

                    VIN = car.VIN,
                    Nazwa = car.Nazwa,
                    modelSamochodu = new ModelSamochoduDto()
                    {

                        Name = _carRepository.getCarModelById(car.ModelSamochoduId).Name,
                        Marka = new MarkaDto()
                        {
                            Name = _carRepository.getCarBrandById(_carRepository.getCarModelById(car.ModelSamochoduId).MarkaId).Name
                        },
                        WersjaNadwozia = new WersjeNadwoziaDto()
                        {
                            Name = _carRepository.getCarBodyById(_carRepository.getCarModelById(car.ModelSamochoduId).WersjaId).Name
                        }
                    },
                    rodzajPaliwa = new PaliwoDto()
                    {
                        Name = _carRepository.getFuelById(car.rodzajPaliwaId).Name
                    },
                    pojemnoscSkokowa = car.pojemnoscSkokowa,
                    przebieg = car.przebieg,
                    nr_rejestracyjny = car.nr_rejestracyjny

                };
                return carDto;
            }
            else
            {
                return null;
            }
        }

        public List<MarkaDtoView>? getBrands(TrustString trust)
        {
            var userId = _personService.getPersonIdByTrustString(trust.trustString);

            if(userId != null)
            {
                var brands = _carRepository.getBrands();

                if(brands != null)
                {
                    var myBrands = new List<MarkaDtoView>();
                    foreach (var brand in brands)
                    {    
                        if (brand.PersonAdderId == 3 || brand.PersonAdderId == 4 || brand.PersonAdderId == userId.Value)
                        {       
                            myBrands.Add(new MarkaDtoView() { Id = brand.Id, Name = brand.Name });
                        }   
                    }
                    return myBrands;
                }
                else
                {
                    return null;
                }  

            }
            return null;

        }

        public List<WersjeNadwoziaDtoShow>? getCarBody(TrustString trust)
        {
            var userId = _personService.getPersonIdByTrustString(trust.trustString);

            if (userId != null)
            {
                var bodys = _carRepository.getBody();

                if (bodys != null)
                {
                    var myBodys = new List<WersjeNadwoziaDtoShow>();
                    foreach (var body in bodys)
                    {
                        if (body.PersonAdderId == 3 || body.PersonAdderId == 4 || body.PersonAdderId == userId.Value)
                        {
                            myBodys.Add(new WersjeNadwoziaDtoShow() { Id = body.Id, Name = body.Name });
                        }
                    }
                    return myBodys;
                }
                else
                {
                    return null;
                }

            }
            return null;

        }

        public List<ModelSamochoduDtoView>? getCarModel(ModelSamochoduDtoGetView trust)
        {
            var userId = _personService.getPersonIdByTrustString(trust.trustString);

            if (userId != null)
            {
                var models = _carRepository.getModel();

                if (models != null)
                {
                    var myModels = new List<ModelSamochoduDtoView> ();
                    foreach (var model in models)
                    {
                        if (model.MarkaId == trust.Marka && model.WersjaId == trust.WersjaNadwozia)
                        {
                            var wersjaNadwozia = _carRepository.getCarBodyById(model.WersjaId);
                            var marka = _carRepository.getCarBrandById(model.MarkaId);

                            myModels.Add(new ModelSamochoduDtoView() {
                                Id = model.Id, 
                                Name = model.Name ,
                                WersjaNadwozia = new WersjeNadwoziaDto() { Name = wersjaNadwozia.Name}, 
                                Marka = new MarkaDto() { Name = marka.Name }
                            });
                        }
                    }
                    return myModels;
                }
                else
                {
                    return null;
                }

            }
            return null;

        }

        public List<PaliwoDtoView>? getFuelType()
        {
            var paliwo = _carRepository.getFuelTypes();
            var paliwoList = new List<PaliwoDtoView>();
            if(paliwo != null)
            {
                foreach(var p in paliwo)
                {
                    paliwoList.Add(new PaliwoDtoView() { Id = p.Id, Name = p.Name });
                }
            }
            else
            {
                return null;
            }
            return paliwoList;
        }

        //adders

        public bool AddCar(SamochodDtoAdd car)
        {

            var userId = _personService.getPersonIdByTrustString(car.trustString);

            if (userId != null)
            {
                if(_carRepository.getFuelById(car.rodzajPaliwaId) != null && _carRepository.getCarModelById(car.modelSamochdouId) != null)
                {
                    //sprawdź czy w systemie nie ma innego samochodu o takiej samej nazwie - u tej samej osoby, sprawdź czy nie ma w systemie innego samochodu o tym samym numerze vin
                    var cars = this.getCarByUserId(userId.Value);
                    if (cars == null || cars.Count == 0)
                    {
                        return _carRepository.AddCar(userId.Value, car);
                    }
                    else
                    {
                        if (cars.Any(x => x.Nazwa == car.Nazwa))
                        {
                            return false;
                        }
                        else
                        {
                            return _carRepository.AddCar(userId.Value, car);
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

        public bool AddBrand(MarkaDtoAdd marka)
        {
            var userId = _personService.getPersonIdByTrustString(marka.trustString);

            if (userId != null)
            {
               var listaMarek = _carRepository.getCarBrandByName(marka.Name);
               var adminList = _personService.getAllAdminsId();
               var managerList = _personService.getAllManagersId();

                if (listaMarek.Any(x => x.PersonAdderId == userId))
                {
                    return false;
                }
                else
                {
                    foreach (var manager in managerList)
                    {
                        if (listaMarek.Any(x => x.PersonAdderId == manager))
                        {
                            return false;
                        }
                    }
                    foreach (var admin in adminList)
                    {
                        if (listaMarek.Any(x => x.PersonAdderId == admin))
                        {
                            return false;
                        }
                    }

                    return _carRepository.AddCarBrand(userId.Value, marka);

                }


            }
            return false;
        }

        public bool AddBody(WersjeNadwoziaDtoAdd model)
        {
            var userId = _personService.getPersonIdByTrustString(model.trustString);

            if (userId != null)
            {
                var listaWersji = _carRepository.getCarBodyWersionByName(model.Name);
                var adminList = _personService.getAllAdminsId();
                var managerList = _personService.getAllManagersId();
                if (listaWersji.Any(x => x.PersonAdderId == userId))
                {
                    return false;
                }
                else
                {
                    foreach (var manager in managerList)
                    {
                        if (listaWersji.Any(x => x.PersonAdderId == manager))
                        {
                            return false;
                        }
                    }
                    foreach (var admin in adminList)
                    {
                        if (listaWersji.Any(x => x.PersonAdderId == admin))
                        {
                            return false;
                        }
                    }
                    return _carRepository.AddCarBody(userId.Value, model);

                }

            }
            return false;
        }

        public bool AddModel(ModelSamochoduDtoAdd model)
        {
            var userId = _personService.getPersonIdByTrustString(model.trustString);

            if (userId != null)
            {
                var listaModeli = _carRepository.getCarModelByName(model.Name);
                var adminList = _personService.getAllAdminsId();
                var managerList = _personService.getAllManagersId();
                if (listaModeli.Any(x => x.PersonAdderId == userId))
                {
                    return false;
                }
                else
                {
                    foreach (var manager in managerList)
                    {
                        if (listaModeli.Any(x => x.PersonAdderId == manager))
                        {
                            return false;
                        }
                    }
                    foreach (var admin in adminList)
                    {
                        if (listaModeli.Any(x => x.PersonAdderId == admin))
                        {
                            return false;
                        }
                    }

                    return _carRepository.AddCarModel(userId.Value, model);

                }

            }

            return false;
        }

        //deleters

        public bool DeleteCar(SamochodDtoDelete sam)
        {
           var user = _personService.getPersonIdByTrustString(sam.trustString);
            
            if(user != null)
            {
                if(_carRepository.DeleteCar(user.Value, sam.Id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }


    }
    
}
