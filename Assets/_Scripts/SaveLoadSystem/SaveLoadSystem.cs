using System.IO;
using UnityEngine;

public class SaveLoadSystem
{
    private string savePath;

    public SaveLoadSystem()
    {
        savePath = Path.Combine(Application.persistentDataPath, "save.json");
    }

    public void Save(PlayerResources resources)
    {
        var json = JsonUtility.ToJson(resources.ToData(), true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Progress saved: {savePath}");
    }

    public bool Load(PlayerResources resources)
    {
        if (!File.Exists(savePath)) return false;

        var json = File.ReadAllText(savePath);
        var data = JsonUtility.FromJson<PlayerResourcesData>(json);
        resources.FromData(data);

        Debug.Log("Progress Loaded");
        return true;
    }
}
