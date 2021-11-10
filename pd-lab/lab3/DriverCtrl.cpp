#include <stdio.h>
#include <Windows.h>
#include <WinNT.h>
#include <Ntddvdeo.h>

// public name of the device
#define szDrive TEXT("\\\\.\\LCD")

int main()
{
	HANDLE hDevice = INVALID_HANDLE_VALUE;
	hDevice = CreateFile(
		szDrive,          // drive to open
		0,                // no access to the drive
		FILE_SHARE_READ | // share mode
		FILE_SHARE_WRITE,
		NULL,             // default security attributes
		OPEN_EXISTING,    // disposition
		0,                // file attributes
		NULL);            // do not copy file attributes

	if (hDevice == INVALID_HANDLE_VALUE)
	{
		printf("Error opening driver (%d)!\n", GetLastError());
		return 1;
	}
	
	BOOL bResult		= FALSE;
	DWORD dwOutputSize	= sizeof(DISPLAY_BRIGHTNESS);
	DISPLAY_BRIGHTNESS  displayBrightness;

	bResult = DeviceIoControl(
		hDevice,
		IOCTL_VIDEO_QUERY_DISPLAY_BRIGHTNESS,
		NULL,
		0,
		&displayBrightness,
		dwOutputSize,
		&dwOutputSize,
		(LPOVERLAPPED)NULL);
	if (!bResult)
	{
		printf("Display brightness DeviceIOControl (%d)!\n", GetLastError());
		return 1;
	}
	 
	if (dwOutputSize != sizeof(displayBrightness))
	{
		printf("Mismatch between input structure size and returned number of bytes!\n");
		return 1;
	}

	DWORD dwNoOfReturnedBytes;
	UCHAR ucOutputBuffer[256];

	bResult = DeviceIoControl(
		hDevice,
		IOCTL_VIDEO_QUERY_SUPPORTED_BRIGHTNESS,
		NULL,
		0,
		&ucOutputBuffer,
		sizeof(ucOutputBuffer),
		&dwNoOfReturnedBytes,
		(LPOVERLAPPED)NULL);
	if (!bResult)
	{
		printf("Supported brightness DeviceIOControl (%d)!\n", GetLastError());
		return 1;
	}

	CloseHandle(hDevice);

	printf("Drive path                = %ws\r\n", szDrive);
	printf("Display brightness AC     = %d\r\n", displayBrightness.ucACBrightness);
	printf("Display brightness DC     = %d\r\n", displayBrightness.ucDCBrightness);
	printf("Display brightness policy = %s\r\n", (displayBrightness.ucDisplayPolicy == DISPLAYPOLICY_BOTH) ? "AC&DC" : ((displayBrightness.ucDisplayPolicy == DISPLAYPOLICY_AC) ? "AC" : "DC"));
	printf("Max backlight level       = %x\r\n", ucOutputBuffer[dwNoOfReturnedBytes - 1]);

	return 0;
}

