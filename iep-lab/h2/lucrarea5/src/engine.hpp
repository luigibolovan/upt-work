#ifndef _ENGINE_HPP
#define _ENGINE_HPP

#include <iostream>

class Engine
{
    private:
        int horsePower;
        std::string manufacturer;

    public:
        Engine(int hp, std::string manufacturer) : horsePower(hp), manufacturer(manufacturer) { }
        int getEngineHP(){ return horsePower; }
        std::string getEngineManufacturer() { return manufacturer; }
};


#endif