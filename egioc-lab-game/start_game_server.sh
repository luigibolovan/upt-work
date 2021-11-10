#!/bin/sh

echo Checking python version
python --version > /dev/null
if [ $? -eq 0 ] 
then
    python ./webgl/main_server.py
fi


echo "Checking python3 version"
python3 --version > /dev/null
if [ $? -eq 0 ] 
then
    echo Python3 ok
    echo Starting server...
    python3 ./webgl/main_server.py
fi