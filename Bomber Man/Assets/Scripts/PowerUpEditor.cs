using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PowerUp))]
public class PowerUpEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PowerUp script = (PowerUp)target;

        GUIContent arrayLabel = new GUIContent("PowerUps");
        script.arrayIdx = EditorGUILayout.Popup(arrayLabel, script.arrayIdx, script.PowerUpNames);
    }
}
