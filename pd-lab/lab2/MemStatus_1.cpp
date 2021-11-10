// MemStatus.cpp : Defines the entry point for the console application.
//

#include <windows.h>
#include <tchar.h>
#include <stdio.h>
#include <stdlib.h>             // For exit

#define PAGELIMIT 32768

DWORD dwPages = 0;
DWORD dwPageSize;
LPTSTR lpNxtPage;

INT PageFaultExceptionFilter(DWORD dwCode)
{
	LPVOID lpvResult;

	// If the exception is not a page fault, exit.

	if (dwCode != EXCEPTION_ACCESS_VIOLATION)
	{
		_tprintf(TEXT("Exception code = %d.\n"), dwCode);
		return EXCEPTION_EXECUTE_HANDLER;
	}

	//_tprintf(TEXT("Exception is a page fault.\n"));

	// If the reserved pages are used up, exit.

	if (dwPages >= PAGELIMIT)
	{
		_tprintf(TEXT("Exception: out of pages.\n"));
		return EXCEPTION_EXECUTE_HANDLER;
	}

	// Otherwise, commit another page.

	lpvResult = VirtualAlloc(
		(LPVOID)lpNxtPage, // Next page to commit
		dwPageSize,         // Page size, in bytes
		MEM_COMMIT,         // Allocate a committed page
		PAGE_READWRITE);    // Read/write access
	if (lpvResult == NULL)
	{
		_tprintf(TEXT("VirtualAlloc failed.\n"));
		return EXCEPTION_EXECUTE_HANDLER;
	}
	else
	{
		//_tprintf(TEXT("Allocating another page.\n"));
	}

	// Increment the page count, and advance lpNxtPage to the next page.

	dwPages++;
	lpNxtPage = (LPTSTR)((PCHAR)lpNxtPage + dwPageSize);

	// Continue execution where the page fault occurred.

	return EXCEPTION_CONTINUE_EXECUTION;
}

int main()
{
	LPTSTR lpPtr;
	BOOL boSuccess;
	SYSTEM_INFO sinfo;

	GetSystemInfo(&sinfo);
	printf("Page size: %d \n", sinfo.dwPageSize);
	dwPageSize = sinfo.dwPageSize;

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

	/**
	* page size = 4kb; page size * 1024 * 32 = 128mb; 
	*/
	LPVOID ptr = VirtualAlloc(NULL, dwPageSize * PAGELIMIT, MEM_COMMIT, PAGE_READWRITE);
	if (ptr == NULL)
	{
		printf("VirtualAlloc failed\r\n");
		exit(31);
	}

	lpPtr = lpNxtPage = (LPTSTR)ptr;

	for (DWORD dwIndex = 0; dwIndex < dwPageSize * PAGELIMIT; dwIndex++)
	{
		__try 
		{
			lpPtr[dwIndex] = 'b';
		}

		__except(PageFaultExceptionFilter(GetExceptionCode()))
		{
			printf("Exiting process\r\n");
			break;
		}
	}


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

	boSuccess = VirtualFree(
		ptr,
		0,
		MEM_RELEASE
	);

	printf("Release %s", boSuccess ? "success" : "failed");

	getchar();

	return 0;
}

