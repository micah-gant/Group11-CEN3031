using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OutputGen))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        OutputGen gen = (OutputGen)target;
        if (GUILayout.Button("Generate Grid"))
        {
            gen.generateTerrain();
        }
    }
}
