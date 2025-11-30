using UnityEngine;
using System.IO;

public static class ApiKeyManager
{
    public static string GetApiKey()
    {
        string apiKey = "";
        string apiKeyPath = Path.Combine(Application.dataPath, "..", "gemini_api_key.txt");
        if (File.Exists(apiKeyPath))
        {
            apiKey = File.ReadAllText(apiKeyPath).Trim();
        }
        else
        {
            Debug.LogError($"API key file not found at: {apiKeyPath}. Please create this file and paste your API key in it.");
        }
        return apiKey;
    }
}