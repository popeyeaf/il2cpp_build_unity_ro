using UnityEngine;
using System.IO;

[System.Serializable]
public class GameSettings
{
    public string resolution;
    public string windowMode;
    public string quality;
    public int volume;
}

public class SettingsManager : MonoBehaviour
{
    private GameSettings gameSettings;
    private string filePath;

    private void Start()
    {
        // ตั้งค่าเส้นทางไฟล์ไปยัง directory ที่มีไฟล์ .exe ของเกม
#if UNITY_EDITOR
        // ใน Unity Editor, เราใช้ที่ตั้งโฟลเดอร์ Assets หรือที่อื่นที่คุณต้องการ
        filePath = Path.Combine(Application.dataPath, "Settings.json");
#else
        // ใน build สำหรับ Windows, เราไปยัง directory ของไฟล์ .exe
        filePath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Settings.json");
#endif
        LoadSettings();
        ApplySettings();
    }

    private void LoadSettings()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameSettings = JsonUtility.FromJson<GameSettings>(json);
        }
        else
        {
            Debug.LogWarning("Settings file not found, creating new one with default settings.");
            gameSettings = new GameSettings
            {
                resolution = "1080p",
                windowMode = "FullScreenWindow",
                quality = "High",
                volume = 100
            };
            SaveSettings();
        }
    }

    private void SaveSettings()
    {
        string json = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(filePath, json);
    }

    private void ApplySettings()
    {
        // Apply resolution
        Resolution resolution = ParseResolution(gameSettings.resolution);
        Screen.SetResolution(resolution.width, resolution.height, ParseWindowMode(gameSettings.windowMode));

        // Apply quality
        QualitySettings.SetQualityLevel(ParseQuality(gameSettings.quality), true);

        // Apply volume
        AudioListener.volume = gameSettings.volume / 100f;
    }

    private Resolution ParseResolution(string resolutionString)
    {
        Resolution resolution = new Resolution();
        switch (resolutionString)
        {
            case "4K":
                resolution.width = 3840;
                resolution.height = 2160;
                break;
            case "2K":
                resolution.width = 2560;
                resolution.height = 1440;
                break;
            case "1080p":
                resolution.width = 1920;
                resolution.height = 1080;
                break;
            case "720p":
                resolution.width = 1280;
                resolution.height = 720;
                break;
            case "540p":
                resolution.width = 960;
                resolution.height = 540;
                break;
            default:
                Debug.LogWarning("Resolution setting not recognized: " + resolutionString);
                resolution = Screen.currentResolution; // Default to current resolution
                break;
        }
        return resolution;
    }

    private FullScreenMode ParseWindowMode(string windowModeString)
    {
        switch (windowModeString)
        {
            case "FullScreen":
                return FullScreenMode.ExclusiveFullScreen;
            case "Windowed":
                return FullScreenMode.Windowed;
            case "FullScreenWindow":
                return FullScreenMode.FullScreenWindow;
            default:
                Debug.LogWarning("Window mode setting not recognized: " + windowModeString);
                return Screen.fullScreenMode; // Default to current window mode
        }
    }

    private int ParseQuality(string qualityString)
    {
        switch (qualityString)
        {
            case "High":
                return 5;
            case "Medium":
                return 3;
            case "Low":
                return 1;
            default:
                Debug.LogWarning("Quality setting not recognized: " + qualityString);
                return QualitySettings.GetQualityLevel(); // Default to current quality level
        }
    }
}
