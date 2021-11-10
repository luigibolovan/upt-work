cmake_minimum_required(VERSION 3.10)

set(PROJECT_SRC_DIR ./src)
set(CMAKE_CXX_COMPILER "/usr/bin/g++")

project(Lucrarea5)

add_executable( Lucrarea5 
                ${PROJECT_SRC_DIR}/engine.cpp
                ${PROJECT_SRC_DIR}/engine.hpp
                ${PROJECT_SRC_DIR}/regular_car.cpp
                ${PROJECT_SRC_DIR}/regular_car.hpp
                ${PROJECT_SRC_DIR}/frunk_car.cpp
                ${PROJECT_SRC_DIR}/frunk_car.hpp
                ${PROJECT_SRC_DIR}/main.cpp)