#ifndef _FRUNK_CAR_HPP
#define _FRUNK_CAR_HPP

#include <iostream>
#include "regular_car.hpp"

class FrunkCar : public RegularCar 
{
    private:
        int frunkCapacity;
    
    public: 
        FrunkCar(int year, std::string name, int trunkCapacity, Engine *engine, int frunkCapacity);
        FrunkCar& operator=(const FrunkCar& newCar);

        int getFrunkCapacity() { return frunkCapacity; }
};

#endif