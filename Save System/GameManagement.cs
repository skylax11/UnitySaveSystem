using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public List<Button> Buttons;   
    public List<TextMeshProUGUI> Texts;
    public List<TMP_InputField> Variables;

    public static Action OnDataSaved;
    public static Action OnDataLoaded;

    private Datas SavedData = new Datas(0,0,"");

    private void Start()
    {
        OnDataSaved += DataSaved;  // Subscribes the OnDataSaved action. Can be expand if needed. 
        OnDataLoaded += DataLoaded;// Subscribes the OnDataLoaded action. Can be expand if needed. 

        Buttons[0].onClick.AddListener( () => InvokeSaveDatasWithBinary());
        Buttons[1].onClick.AddListener( () => InvokeLoadDatasWithBinary());
        Buttons[2].onClick.AddListener( () => InvokeSaveDatasWithJSON());
        Buttons[3].onClick.AddListener( () => InvokeLoadDatasWithJSON());


        InvokeLoadDatasWithBinary();
    }
    /// <summary> Save datas in the binary converter way. </summary>
    public void InvokeSaveDatasWithBinary()
    {
        OnDataSaved?.Invoke();

        SavedData.PlayerName = Variables[0].text;
        SavedData.Health = Convert.ToInt32(Variables[1].text);
        SavedData.Stamina = Convert.ToInt32(Variables[2].text);

        SaveSystem.SaveDatasBinary(SavedData);
    }
    /// <summary> Save datas with JSON file</summary>
    private void InvokeSaveDatasWithJSON()
    {
        OnDataSaved?.Invoke();

        SavedData.PlayerName = Variables[0].text;
        SavedData.Health = Convert.ToInt32(Variables[1].text);
        SavedData.Stamina = Convert.ToInt32(Variables[2].text);

        SaveSystem.SaveDatasJSON(SavedData);
    }
    private void InvokeLoadDatasWithBinary()
    {
        PlayerScript.data = SaveSystem.LoadDatasBinary();
        OnDataLoaded?.Invoke();
    }
    private void InvokeLoadDatasWithJSON()
    {
        PlayerScript.data = SaveSystem.LoadDatasJSON();
        OnDataLoaded?.Invoke();
    }
    private void DataSaved()
    {
        print("Data has been saved and Action Invoked.");

    }
    private void DataLoaded()
    {
        print("Data has been loaded and Action Invoked.");
        UpdateUI();
    }
    private void UpdateUI()
    {

        Texts[0].text = PlayerScript.data.PlayerName;
        Texts[1].text = PlayerScript.data.Health.ToString();
        Texts[2].text = PlayerScript.data.Stamina.ToString();
    }
}
