using WarsztatApi.Dto;

namespace WarsztatApi.Services.Interfaces
{
    public interface ICarService
    {
        //tests
        public bool test();

        public bool testRepo();
        //getters
        public List<SamochodDtoView>? getCarByUserId(int id);

        public List<MarkaDtoView>? getBrands(TrustString trust);

        public List<WersjeNadwoziaDtoShow>? getCarBody(TrustString trust);

        public List<ModelSamochoduDtoView>? getCarModel(ModelSamochoduDtoGetView trust);

        public SamochodDto? getCarByVinNumber(string vinNumber);

        public List<PaliwoDtoView>? getFuelType();
        //adders
        public bool AddCar(SamochodDtoAdd car);

        public bool AddBrand(MarkaDtoAdd marka);

        public bool AddBody(WersjeNadwoziaDtoAdd model);

        public bool AddModel(ModelSamochoduDtoAdd model);

        //deleters

        public bool DeleteCar(SamochodDtoDelete sam);

    }
}
