#include "frunk_car.hpp"

FrunkCar::FrunkCar(int year, std::string name, int trunkCapacity, Engine *engine, int frunkCapacity)
            :   RegularCar(year, name, trunkCapacity, engine),
                frunkCapacity(frunkCapacity)
{
    std::cout << "created frunk car" << std::endl;
}

FrunkCar& FrunkCar::operator=(const FrunkCar& newCar)
{
    RegularCar::operator=(newCar);          // Item 12: Copy all parts of an object.
    frunkCapacity = newCar.frunkCapacity;   // Item 12: Copy all parts of an object.

    return *this;
}