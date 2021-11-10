#ifndef PERSON_H
#define PERSON_H

#include <iostream>

class Person
{
    private:
        int id;
        std::string name;
        std::string email;
        
        // item 6: explicitly disable the use of compiler generated functions you do not want
        Person& operator=(const Person&);
    
    public:
       Person(int id, std::string name, std::string mail);
       Person(const Person& copyPerson){ std::cout << "Copy constructor called" << std::endl;}

       std::string getName() { return name; }
       std::string getEmail() { return email; }
};

#endif