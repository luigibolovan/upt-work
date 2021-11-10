#ifndef _CAR_HPP
#define _CAR_HPP

#include <iostream>
#include "engine.hpp"

class RegularCar
{
    protected: 
        int year;
        std::string modelName;
        int trunkCapacity;
        Engine *engine;
        RegularCar(const RegularCar& car2copy); //copy constructor disabled

    public:
        RegularCar(int year, std::string model, int trunkCap, Engine *engine);
        RegularCar& operator=(const RegularCar& car);

        int getEngineHP() { return engine->getEngineHP(); }
        std::string getEngineManufacturer() { return engine->getEngineManufacturer(); }
        
        int getYear() { return year; }
        std::string getModelName() { return modelName; }
        int getTrunkCapacity() { return trunkCapacity; }
        Engine* getEngine() { return this->engine; }
};


#endif