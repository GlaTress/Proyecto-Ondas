using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[SerializeField]
public class PlayerInfo : MonoBehaviour
{
    public TMP_Text txtDinero;
    public SaveManager saveManager;

    void Start()
    {
        saveManager.DataLoaded += onDataLoaded;
    }
    
    [ContextMenu("Saveee")]
    void onDataLoaded()
    {
        OnMoneyChanged(saveManager.playerdata.dineroGuardado);
    }
    [ContextMenu("Save")]
    public void onSaveClick()
    {
        saveManager.Save();
    }
    [ContextMenu("LOad")]
    public void onLoadClick()
    {
        saveManager.Load();
    }
    public void OnMoneyChanged(int dineroGuardado)
    {
         txtDinero.text = dineroGuardado.ToString();
    }
    
}
