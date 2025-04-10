using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

[SLua.CustomLuaClassAttribute]
public class DeviceInfo
{
	public static string GetModel()
	{
		return SystemInfo.deviceModel;
	}

	public static string GetName()
	{
		return SystemInfo.deviceName;
	}

	public static string GetID()
	{
		return SystemInfo.deviceUniqueIdentifier;
	}

	public static int GetScreenWidth()
	{
		return Screen.width;
	}

	public static int GetScreenHeight()
	{
		return Screen.height;
	}

	public static string GetCPUName()
	{
		return SystemInfo.processorType;
	}

	public static int GetCPUCoresCount()
	{
		return SystemInfo.processorCount;
	}

	public static int GetSizeOfRAM()
	{
		return SystemInfo.systemMemorySize;
	}

	[DllImport("__Internal")]
	private extern static long _getTotalMemory();
	public static long GetSizeOfMemory()
	{
		long size = 0;
#if UNITY_EDITOR_OSX
		DriveInfo[] drives = DriveInfo.GetDrives();
		foreach(DriveInfo drive in drives)
		{
			size += drive.TotalSize;
		}
#elif UNITY_IPHONE
		size = _getTotalMemory();
#elif UNITY_ANDROID
		size = GetSizeOfExternalMemory();
#endif
		return size;
	}

	[DllImport("__Internal")]
	private extern static long _getFreeMemory();
	public static long GetSizeOfValidMemory()
	{
		long size = 0;

#if UNITY_EDITOR
		// Uncomment the following lines if you want to calculate the free space across all drives in the Unity Editor
		//DriveInfo[] drives = DriveInfo.GetDrives();
		//foreach(DriveInfo drive in drives)
		//{
		//	size += drive.AvailableFreeSpace;
		//}
		size = uint.MaxValue;
#elif UNITY_STANDALONE_WIN
    // For Windows users, get the free space of the primary (C:) drive
    DriveInfo cDrive = new DriveInfo("C");
    if(cDrive.IsReady)
    {
        size = cDrive.AvailableFreeSpace;
    }
#elif UNITY_IPHONE
    size = _getFreeMemory();
#elif UNITY_ANDROID
    size = GetSizeOfFreeExternalMemory();
#endif

		return size;
	}

#if UNITY_ANDROID && !UNITY_EDITOR
	private static AndroidJavaObject m_currentActivity;
	private static AndroidJavaObject CurrentActivity
	{
		get
		{
			if (m_currentActivity == null)
			{
				AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				m_currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
			}
			return m_currentActivity;
		}
	}
#endif

	public static long GetSizeOfInternalMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("totalInternalMemory");
#endif
		return size;
	}

	public static long GetSizeOfValidInternalMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("availableInternalMemory");
#endif
		return size;
	}

	public static long GetSizeOfFreeInternalMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("freeInternalMemory");
#endif
		return size;
	}

	public static long GetSizeOfExternalMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
    AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    size = currentActivity.Call<long>("totalExternalMemory");
#endif
		return size;
	}


	public static long GetSizeOfValidExternalMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("availableExternalMemory");
#endif
		return size;
	}

	public static long GetSizeOfFreeExternalMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("freeExternalMemory");
#endif
		return size;
	}

	public static long GetSizeOfDataMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("totalDataMemory");
#endif
		return size;
	}

	public static long GetSizeOfValidDataMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("availableDataMemory");
#endif
		return size;
	}
	
	public static long GetSizeOfFreeDataMemory()
	{
		long size = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
		size = CurrentActivity.Call<long>("freeDataMemory");
#endif
		return size;
	}

	public static void ExternalStorageState()
	{
#if UNITY_ANDROID && !UNITY_EDITOR
		CurrentActivity.Call("externalStorageState");
#endif
	}

	public static string GetGPUName()
	{
		return SystemInfo.graphicsDeviceName;
	}

	public static string GetGPUType()
	{
		return SystemInfo.graphicsDeviceType.ToString();
	}

	public static string GetUserIp()
	{
		return System.Net.Dns.GetHostName();
	}
}
