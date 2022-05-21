using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DevelopmentWindow: EditorWindow
{
    private int _currentWeapon = 0;

    [MenuItem("Diorsis/Development Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(DevelopmentWindow), false, "Development");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);
        EditorGUILayout.Space();

    }

}