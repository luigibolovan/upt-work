cmake_minimum_required(VERSION 3.10)

set(PROJECT_SRC_DIR ./src)
set(CMAKE_CXX_COMPILER "/usr/bin/g++")

project(Person_dummy_project)

add_executable( Person_dummy_project 
                ${PROJECT_SRC_DIR}/person.cpp
                ${PROJECT_SRC_DIR}/person.h)