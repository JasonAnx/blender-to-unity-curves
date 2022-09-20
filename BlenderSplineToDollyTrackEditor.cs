using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlenderSplineToDollyTrack))]
public class BlenderSplineToDollyTrackEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        BlenderSplineToDollyTrack inst = (BlenderSplineToDollyTrack)target;

        GUILayout.Space(20);
        var btnstyle = new GUIStyle(GUI.skin.button);
        btnstyle.alignment = TextAnchor.MiddleCenter;
        btnstyle.fixedWidth = 100;
        if (GUILayout.Button("Build", btnstyle)) {
            if (!inst.jsonFile) throw new System.Exception("json file not set");
            var path = AssetDatabase.GetAssetPath(inst.jsonFile);
            inst.doJob(path);
        }
    }
}
