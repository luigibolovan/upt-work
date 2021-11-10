#include <iostream>
#include <Windows.h>
#include <tchar.h>
#include <stdio.h>


#define MAX_NAME_LENGTH         511
#define MAX_IMAGE_PATH_LENGTH   1023
#define KERNEL_DEVICE_DRIVER    0x01UL
#define FILE_SYSTEM_DRIVER      0x02UL


using namespace std;


LPCWSTR pachPathToDrivers = L"SYSTEM\\CurrentControlSet\\Services";


HKEY hGetKeyHandle(HKEY hRoot, LPCWSTR pachPath)
{
    HKEY hResult;
    LSTATUS status = RegOpenKeyEx(
        hRoot,
        pachPath,
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

void printImagePathForDriverSubkeys(HKEY hRootKeyHandle, DWORD dwNoOfSubKeys)
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
            HKEY hSubkeyHandle      = hGetKeyHandle(hRootKeyHandle, achKeyName);
            DWORD dwDriverType      = REG_DWORD;
            LPBYTE lpbDriverData    = (LPBYTE)malloc(4 * sizeof(BYTE));
            DWORD dwDriverDataSize  = 4;

            // driver query
            LSTATUS statusQueryValueDriverType = RegQueryValueEx(
                hSubkeyHandle,
                L"Type",
                NULL,
                &dwDriverType,
                lpbDriverData,
                &dwDriverDataSize);

            if (statusQueryValueDriverType != ERROR_SUCCESS)
            {
                if (statusQueryValueDriverType == ERROR_FILE_NOT_FOUND)
                {
                    // do nothing, it might not have Type value
                }
                else
                {
                    _tprintf(L"Failed to query driver type value\r\n");
                }
            }
            if ((lpbDriverData[0] == KERNEL_DEVICE_DRIVER) || (lpbDriverData[0] == FILE_SYSTEM_DRIVER))
            {
                // ImagePath query
                DWORD dwImgPathType     = REG_EXPAND_SZ;
                LPBYTE lpbImgPathData   = (LPBYTE)malloc(MAX_IMAGE_PATH_LENGTH * sizeof(BYTE));
                DWORD dwImgPathDataSize = MAX_IMAGE_PATH_LENGTH;
                LSTATUS statusQueryValueImgPath = RegQueryValueEx(
                    hSubkeyHandle,
                    L"ImagePath",
                    NULL,
                    &dwImgPathType,
                    lpbImgPathData,
                    &dwImgPathDataSize);

                    if (statusQueryValueImgPath != ERROR_SUCCESS)
                    {
                        if (statusQueryValueImgPath == ERROR_FILE_NOT_FOUND)
                        {
                            // do nothing, it might not have ImagePath value
                        }
                        else
                        {
                            _tprintf(L"Failed to query imagepath value\r\n");
                        }
                    }
                    else
                    {
                        _tprintf(L"%s - Type: %d - ImagePath: %ws\r\n", achKeyName, lpbDriverData[0], (LPCWSTR)lpbImgPathData);
                    }
            }
            else
            {
                // not a driver
            }

            closeKeyHandle(hSubkeyHandle);
        }
    }
}

int _tmain()
{
    HKEY hDriverKeyHandle = hGetKeyHandle(HKEY_LOCAL_MACHINE, pachPathToDrivers);
    DWORD dwNumberOfSubkeys = dwGetNumberOfSubkeys(hDriverKeyHandle);
    printImagePathForDriverSubkeys(hDriverKeyHandle, dwNumberOfSubkeys);
    closeKeyHandle(hDriverKeyHandle);

    return 0;
}

