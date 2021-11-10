#pragma warning(disable:4996)

#include <iostream>
#include <Windows.h>
#include <tchar.h>
#include <stdio.h>


#define MAX_NAME_LENGTH 511
#define MAX_IMAGE_PATH_LENGTH 1023


using namespace std;


LPCWSTR pachPathToDrivers = L"SYSTEM\\CurrentControlSet\\Services";


HKEY hGetKeyHandle(HKEY root, LPCWSTR path)
{
    HKEY hResult;
    LSTATUS status = RegOpenKeyEx(
        root,
        path,
        0L,
        KEY_READ,
        &hResult);

    if (status != ERROR_SUCCESS)
    {
        _tprintf(L"Failed when opening key\r\n");
        exit(1);
    }
    else
    {
        return hResult;
    }
}

void closeKeyHandle(HKEY hKeyHandle)
{
    if (RegCloseKey(hKeyHandle) != ERROR_SUCCESS)
    {
        _tprintf(L"Could not close key handle\r\n");
    }
}

DWORD dwGetNumberOfSubkeys(HKEY hKeyHandle)
{
    DWORD dwNoOfSubKeys = 0;
    
    LSTATUS status = RegQueryInfoKey(
        hKeyHandle,
        NULL,
        NULL,
        NULL,
        &dwNoOfSubKeys,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL);

    if (status != ERROR_SUCCESS)
    {
        _tprintf(L"Failed when getting number of subkeys for key handle\r\n");
        exit(2);
    }
    else
    {
        return dwNoOfSubKeys;
    }
}

void printImagePathForSubkeys(HKEY hRootKeyHandle, DWORD dwNoOfSubKeys)
{
    DWORD dwIndex = 0;
    for (dwIndex = 0; dwIndex < dwNoOfSubKeys; dwIndex++)
    {  
        TCHAR achKeyName[MAX_NAME_LENGTH];
        DWORD dwNameSize = MAX_NAME_LENGTH;
        LSTATUS statusEnumKey = RegEnumKeyEx(
            hRootKeyHandle,
            dwIndex,
            achKeyName,
            &dwNameSize,
            NULL,
            NULL,
            NULL,
            NULL);

        if (statusEnumKey != ERROR_SUCCESS)
        {
            _tprintf(L"Failed when getting name of the subkey\r\n");
        }
        else
        {
            HKEY hSubkeyHandle = hGetKeyHandle(hRootKeyHandle, achKeyName);
            DWORD dwType = REG_EXPAND_SZ;
            LPBYTE lpbData = (LPBYTE)malloc(MAX_IMAGE_PATH_LENGTH * sizeof(BYTE));
            DWORD dwDataSize = MAX_IMAGE_PATH_LENGTH;

            LSTATUS statusQueryValue = RegQueryValueEx(
                hSubkeyHandle,
                L"ImagePath",
                NULL,
                &dwType,
                lpbData,
                &dwDataSize);
            
            if (statusQueryValue != ERROR_SUCCESS)
            {
                if (statusQueryValue == ERROR_FILE_NOT_FOUND)
                {
                    // do nothing, it might not have ImagePath value
                }
                else
                {
                    _tprintf(L"Failed to query value\r\n");
                }
            }
            else
            {
                _tprintf(L"%s ImagePath: %ws\r\n", achKeyName, (LPCWSTR)lpbData);
            }

            closeKeyHandle(hSubkeyHandle);
        }
    }
}

int _tmain()
{
    HKEY hDriverKeyHandle = hGetKeyHandle(HKEY_LOCAL_MACHINE, pachPathToDrivers);
    DWORD dwNumberOfSubkeys = dwGetNumberOfSubkeys(hDriverKeyHandle);
    printImagePathForSubkeys(hDriverKeyHandle, dwNumberOfSubkeys);
    closeKeyHandle(hDriverKeyHandle);

    return 0;
}

