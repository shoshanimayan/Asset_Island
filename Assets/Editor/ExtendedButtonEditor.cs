using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExtendedButton))]
public class ExtendedButtonEditor :Editor
{
   
    public override void OnInspectorGUI()
    {

        
        // Show default inspector property editor
        DrawDefaultInspector();
      
    }
}
