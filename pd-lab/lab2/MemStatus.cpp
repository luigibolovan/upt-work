// MemStatus.cpp : Defines the entry point for the console application.
//

#include <stdio.h>
#include <tchar.h>
#include <Windows.h>

int main()
{
	SYSTEM_INFO sinfo;
	GetSystemInfo(&sinfo);
	printf("Page size: %d \n", sinfo.dwPageSize);
	printf("Min address: %x \n", (unsigned long)sinfo.lpMinimumApplicationAddress);
	printf("Max address: %x \n", (unsigned long)sinfo.lpMaximumApplicationAddress);

	MEMORYSTATUSEX memStat;
	memStat.dwLength = sizeof(MEMORYSTATUSEX);
	if (GlobalMemoryStatusEx(&memStat) == 0)
	{
		printf("memory status access error (%d)!\n", GetLastError());
		return 1;
	}

	printf("MemoryLoad: %d%%\n", memStat.dwMemoryLoad);
	printf("TotalPhys: %lld\n", memStat.ullTotalPhys);
	printf("AvailablePhys: %lld\n", memStat.ullAvailPhys);
	printf("TotalVirtual: %lld\n", memStat.ullTotalVirtual);
	printf("AvailableVirtual: %lld\n", memStat.ullAvailVirtual);

	WCHAR *wString = (WCHAR *)calloc(300000, sizeof(WCHAR));
	printf("%x\r\n", sizeof(WCHAR));
	printf("Start address of unicode dinamically allocated string: %x\r\n", wString);
	printf("End address of unicode dinamically allocated string: %x\r\n", &wString[299999]);

	memStat.dwLength = sizeof(MEMORYSTATUSEX);
	if (GlobalMemoryStatusEx(&memStat) == 0)
	{
		printf("memory status access error (%d)!\n", GetLastError());
		return 1;
	}

	printf("MemoryLoad: %d%%\n", memStat.dwMemoryLoad);
	printf("TotalPhys: %lld\n", memStat.ullTotalPhys);
	printf("AvailablePhys: %lld\n", memStat.ullAvailPhys);
	printf("TotalVirtual: %lld\n", memStat.ullTotalVirtual);
	printf("AvailableVirtual: %lld\n", memStat.ullAvailVirtual);

	printf("Virtual address: &sinfo = %08Xh\n", (unsigned long)&sinfo);

	return 0;
}

