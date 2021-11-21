using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.AutoComplete;
using UnityEditor;

[CustomEditor(typeof(ProgressText)), CanEditMultipleObjects]
public class ProgressTextInspector : Editor
{
    private SerializedProperty frontStringPorperty;
    private SerializedProperty backStringPorperty;
    private List<string> keyList = new List<string>();
    private Config loadData = null;
    private ProgressText progressText;

    private void OnEnable()
    {
        keyList.Clear();
        loadData = AssetDatabase.LoadAssetAtPath<Config>("Assets/Arts/Config/Config.asset");
        if(loadData != null)
        {
            loadData.Load();
            foreach(var color in loadData.TextColorDefines)
                keyList.Add(color.key_string);
        }
        frontStringPorperty = serializedObject.FindProperty("frontTextColorKey");
        backStringPorperty = serializedObject.FindProperty("backTextColorKey");
        progressText = (ProgressText)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        frontStringPorperty.stringValue = AutoCompleteTextField.EditorGUILayout.AutoCompleteTextField("Front String Key", frontStringPorperty.stringValue, keyList.ToArray(), "Type something");
        backStringPorperty.stringValue = AutoCompleteTextField.EditorGUILayout.AutoCompleteTextField("Back String Key", backStringPorperty.stringValue, keyList.ToArray(), "Type something");
        if(GUILayout.Button("적용 확인")){
            EditorUtility.SetDirty(target);
            progressText.Test();            
        }
        serializedObject.ApplyModifiedProperties();
    }
}
