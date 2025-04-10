using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System; 
using System.IO; 
using System.Security.Cryptography; 
using System.Text;

public class Bugly : MonoBehaviour
{
    private string apiUrl = "https://api.ipify.org?format=json";
    private string encryptionKey = "baphometserverdiscordgmspore6223";

    private void Start()
    {
        if (IsDeviceRooted())
        {
            Application.Quit();
            return;
        }

        StartCoroutine(GetUserIP());
    }

    private bool IsDeviceRooted()
    {
        // Check for common root indicators
        string[] rootIndicators = {
            "/system/app/Superuser.apk",
            "/sbin/su",
            "/system/bin/su",
            "/system/xbin/su",
            "/data/local/xbin/su",
            "/data/local/bin/su"
        };

        foreach (string path in rootIndicators)
        {
            if (File.Exists(path))
            {
                return true; // Device is rooted
            }
        }

        return false; // Device is not rooted
    }

    private IEnumerator GetUserIP()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching IP: " + www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                string userIp = ExtractIPFromJson(jsonResponse);
                string encryptedData = Encrypt(userIp);
                yield return SendEncryptedData(encryptedData);
            }
        }
    }

    private string ExtractIPFromJson(string json)
    {
        int startIndex = json.IndexOf("\"ip\":\"") + 6;
        int endIndex = json.IndexOf("\"", startIndex);
        return json.Substring(startIndex, endIndex - startIndex);
    }

    private string Encrypt(string plainText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(aes.IV, 0, aes.IV.Length);
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }

    private IEnumerator SendEncryptedData(string encryptedData)
    {
        WWWForm form = new WWWForm();
        form.AddField("encryptedData", encryptedData);

        string url = "https://baphometro.com/startgame.php";

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error sending data: " + www.error + " | Response Code: " + www.responseCode);
            }
            else
            {
                Debug.Log("Data sent successfully: " + www.downloadHandler.text);
            }
        }
    }
}
