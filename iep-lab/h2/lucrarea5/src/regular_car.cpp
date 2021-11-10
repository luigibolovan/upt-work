#include "regular_car.hpp"
#include <algorithm>
#include <vector>

RegularCar::RegularCar(int year, std::string model, int trunkCap, Engine *engine)
                :engine(engine),
                year(year),
                modelName(model),
                trunkCapacity(trunkCap)
{
    std::cout << "Created new regular car" << std::endl;
}

// Item 11: Handle assignment to self in operator=.
RegularCar& RegularCar::operator=(const RegularCar& newCar)
{
    this->year = newCar.year;
    this->modelName = newCar.modelName;
    this->trunkCapacity = newCar.trunkCapacity;
    
    Engine *currentEng = this->engine; 
    this->engine = new Engine(*newCar.engine);      
    delete currentEng;                 

    return *this; // item 10: Have assignment operators return a reference to *this.
}