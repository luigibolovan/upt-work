cmake_minimum_required(VERSION 3.10)

set(PROJECT_SRC_DIR ./src)
set(CMAKE_CXX_COMPILER "/usr/bin/g++")

project(Lucrarea6)

add_executable( Lucrarea6 
                ${PROJECT_SRC_DIR}/file_handler.cpp)