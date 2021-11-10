#include "frunk_car.hpp"
#include "regular_car.hpp"


int main()
{
    //heap allocated engines
    Engine *mazda3Engine = new Engine(122, "Mazda");
    Engine *engineMazdaX = new Engine(184, "Mazda");
    Engine *engineVAG    = new Engine(190, "VAG");
    Engine *engineTesla3 = new Engine(283, "Tesla");
    Engine *engineTeslaS = new Engine(416, "Tesla");


    RegularCar mazda3G(2020, "Mazda3", 350, mazda3Engine);
    RegularCar audiA4(2019, "AudiA4", 450, engineVAG);
    RegularCar mazda3X(2020, "Mazda3 SkyActiv X", 350, engineMazdaX);

    FrunkCar tesla3(2019, "Tesla Model 3", 321, engineTesla3, 100);
    FrunkCar teslaS(2017, "Tesla Model S", 400, engineTeslaS, 122);

    mazda3G = mazda3G;
    std::cout << "\nModel: " << mazda3G.getModelName() << std::endl;
    std::cout << "Year: " << mazda3G.getYear() << std::endl;
    std::cout << "Engine power: " << mazda3G.getEngineHP() << std::endl;
    std::cout << "Engine manufacturer: " << mazda3G.getEngineManufacturer() << std::endl;
    std::cout << "Trunk capacity: " << mazda3G.getTrunkCapacity() << std::endl;



    mazda3G = mazda3X;
    std::cout << "\nModel: " << mazda3G.getModelName() << std::endl;
    std::cout << "Year: " << mazda3G.getYear() << std::endl;
    std::cout << "Engine power: " << mazda3G.getEngineHP() << std::endl;
    std::cout << "Engine manufacturer: " << mazda3G.getEngineManufacturer() << std::endl;
    std::cout << "Trunk capacity: " << mazda3G.getTrunkCapacity() << std::endl;




    tesla3 = teslaS;
    std::cout << "\nModel: " << tesla3.getModelName() << std::endl;
    std::cout << "Year: " << tesla3.getYear() << std::endl;
    std::cout << "Engine power: " << tesla3.getEngineHP() << std::endl;
    std::cout << "Engine manufacturer: " << tesla3.getEngineManufacturer() << std::endl;
    std::cout << "Trunk capacity: " << tesla3.getTrunkCapacity() << std::endl;
    std::cout << "Frunk capacity: " << tesla3.getFrunkCapacity() << std::endl;

    return 0;
}