using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generate_WFC_Grid))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Generate_WFC_Grid gen = (Generate_WFC_Grid)target;
        if (GUILayout.Button("Generate Grid"))
        {
            gen.generate();
        }
    }
}
