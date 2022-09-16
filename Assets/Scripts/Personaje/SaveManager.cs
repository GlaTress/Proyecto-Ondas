using System.IO;
using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string FileName = "playerData.data";

    public event Action DataLoaded;

    [SerializeField]
    public PlayerData playerdata;
    private PlayerData PlayerData => playerdata;

    [ContextMenu("Save")]
    public void Save()
    {
        string playerdataJson = JsonUtility.ToJson(playerdata);
        string path = Path.Combine(Application.persistentDataPath, FileName);
        File.WriteAllText(path, playerdataJson);
        

        Debug.Log(path);
    }
    [ContextMenu("Load")]
    public void Load()
    {
        string path = Path.Combine(Application.persistentDataPath, FileName);
        string playerdataJson = File.ReadAllText(path);
        PlayerData playerDataLoaded = JsonUtility.FromJson<PlayerData>(playerdataJson);
        playerdata.dineroGuardado = playerDataLoaded.dineroGuardado;

        DataLoaded?.Invoke();
    }
}
