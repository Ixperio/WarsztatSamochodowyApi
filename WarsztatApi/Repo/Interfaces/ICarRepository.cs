using DB.Entities;
using WarsztatApi.Dto;

namespace WarsztatApi.Repo.Interfaces
{
    public interface ICarRepository
    {
        //tests
        public bool test();

        //getters
        public Samochod? getCarByVinNumber(string vinNumber);

        public List<Samochod>? getUserCars(int id);

        public Paliwo? getFuelById(int id);

        public ModelSamochodu? getCarModelById(int id);

        public Marka? getCarBrandById(int id);
        public WersjeNadwozia? getCarBodyById(int id);

        public List<Marka>? getBrands();
        public List<Marka>? getCarBrandByName(string name);

        public List<WersjeNadwozia>? getBody();
        public List<WersjeNadwozia>? getCarBodyWersionByName(string name);

        public List<ModelSamochodu>? getModel();
        public List<ModelSamochodu>? getCarModelByName(string name);

        public List<Paliwo>? getFuelTypes();

        //adders
        public bool AddCar(int userId, SamochodDtoAdd car);

        public bool AddCarBrand(int userId, MarkaDtoAdd brand);

        public bool AddCarBody(int userId, WersjeNadwoziaDtoAdd model);

        public bool AddCarModel(int userId, ModelSamochoduDtoAdd model);

        //deleters

        public bool DeleteCar(int userId, int carId);
    }
}
