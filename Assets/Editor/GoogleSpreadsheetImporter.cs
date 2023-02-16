using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.IO;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEditor.AddressableAssets;

public class ImportedData
{
    public string range;
    public string majorDimension;
    public string[][] values;
}

public class GoogleSpreadsheetImporter : EditorWindow
{
    private string _url = "";
    private string _savePath;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Path"))
        {
            _url = PlayerPrefs.GetString("Path");
        }
        if (PlayerPrefs.HasKey("SavePath"))
        {
            _savePath = PlayerPrefs.GetString("SavePath");
        }
    }

    private async void ImportSpreadSheet()
    {
        PlayerPrefs.SetString("Path", _url);
        PlayerPrefs.SetString("SavePath", _savePath);

        await ApiGet();
    }

    private async Task ApiGet()
    {
        string returnValue = null;

        using var request = UnityWebRequest.Get(_url);

        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();
        EditorUtility.DisplayProgressBar("Importing Json", "Importing",0);
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        EditorUtility.ClearProgressBar();
        if (request.result == UnityWebRequest.Result.Success)
        {
            returnValue = request.downloadHandler.text;

        }
        else
        {

            Debug.LogError(request.downloadHandler.text);
        }

        using (StreamWriter view = File.CreateText( _savePath+"/ImportedJson.json"))
        {
            view.WriteLine(returnValue);

        }

        var settings = AddressableAssetSettingsDefaultObject.Settings;
        if (settings)
        {

            var group = settings.DefaultGroup;
            if (!group)
                group = settings.CreateGroup(settings.DefaultGroup.Name, false, false, true, null, typeof(ContentUpdateGroupSchema), typeof(BundledAssetGroupSchema));

            var assetpath = _savePath + "/ImportedJson.json";
            var guid = AssetDatabase.AssetPathToGUID(assetpath);

            var e = settings.CreateOrMoveEntry(guid, group, false, false);
            
            e.SetAddress("ImportedJson");

            var entriesAdded = new List<AddressableAssetEntry> { e };

            group.SetDirty(AddressableAssetSettings.ModificationEvent.EntryMoved, entriesAdded, false, true);
            settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryMoved, entriesAdded, true, false);

        }
        EditorUtility.ClearProgressBar();

    }




    public void OnGUI()
    {
        GUILayout.Label("Import Spreadsheet", EditorStyles.boldLabel);
        _url = EditorGUILayout.TextField("Spreadsheet Path ", _url);
        _savePath = EditorGUILayout.TextField("Path To Save At ", _savePath);

        if (GUILayout.Button("Import"))
        {
            ImportSpreadSheet();
            this.Close();

        }

    }

    [MenuItem("TextImport/ImportSpreadSheet")]
    public static void ShowWindow()
    {

        EditorWindow.GetWindow(typeof(GoogleSpreadsheetImporter));
    }
}
