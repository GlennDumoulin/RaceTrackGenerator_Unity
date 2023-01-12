using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackGenerator))]
public class TrackGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TrackGenerator mapGen = (TrackGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.AutoUpdate)
                mapGen.GenerateTrack();
        }

        if (GUILayout.Button("Generate"))
            mapGen.GenerateTrack();
    }
}
