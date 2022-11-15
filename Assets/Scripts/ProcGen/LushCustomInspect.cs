using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Lush_Bounds_Behavior))]
public class LushCustomInspect : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Lush_Bounds_Behavior Lush_Bounds = (Lush_Bounds_Behavior)target;
        if (GUILayout.Button("Expand Lush Area"))
        {
            Lush_Bounds.inspectorExpandLush();
        }
    }
}
