using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Upgrade))]
public class UpgrageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Upgrade script = (Upgrade)target;

        GUIContent arrayLabel = new GUIContent("Upgrades");
        script.arrayIdx = EditorGUILayout.Popup(arrayLabel, script.arrayIdx, script.Upgrades);
    }
}
