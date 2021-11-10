#include "person.h"


// item 4: make sure that objects are initalized before they're used
Person::Person(int id, std::string name, std::string mail)
    :id(id),
    name(name),
    email(mail)
{
        std::cout << "Person "<< name << " initialized" << std::endl;
}

int main()
{
    // item 5: know what functions C++ silently writes and calls
    Person p1(1, "Name", "mymail@gmail.com"); // initialization constructor called
    Person p2(p1);  // copy constructor called
    Person p3 = p1; // copy constructor called

    std::cout << "p2 name" << p2.getName() << std::endl; //constructor copy not default so no name
    std::cout << "p2 email" << p2.getEmail() <<std::endl; // constructor copy not default so no email

    // error
    // item 6: explicitly disable the use of compiler generated functions you do not want
    // p2 = p1; 

    return 0;
}
