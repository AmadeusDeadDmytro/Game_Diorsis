using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraSettings))]
[CanEditMultipleObjects]
public class CameraEditor: Editor
{
    private SerializedProperty minXPosition;
    private SerializedProperty maxXPosition;
    private SerializedProperty minYPosition;
    private SerializedProperty maxYPosition;

    private void OnEnable()
    {
        minXPosition = serializedObject.FindProperty("minXPosition");
        maxXPosition = serializedObject.FindProperty("maxXPosition");
        minYPosition = serializedObject.FindProperty("minYPosition");
        maxYPosition = serializedObject.FindProperty("maxYPosition");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min X Position: " + minXPosition.floatValue);
        if (GUILayout.Button("Apply"))
        {
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            minXPosition.floatValue = cameraObject.transform.position.x;
        } 
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Max X Position: " + maxXPosition.floatValue);
        if (GUILayout.Button("Apply"))
        {
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            maxXPosition.floatValue = cameraObject.transform.position.x;
        } 
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min Y Position: " + minYPosition.floatValue);
        if (GUILayout.Button("Apply"))
        {
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            minYPosition.floatValue = cameraObject.transform.position.y;
        } 
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Max Y Position: " + maxYPosition.floatValue);
        if (GUILayout.Button("Apply"))
        {
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            maxYPosition.floatValue = cameraObject.transform.position.y;
        } 
        EditorGUILayout.EndHorizontal();
        
        serializedObject.ApplyModifiedProperties();
    }
}