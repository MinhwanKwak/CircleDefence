using UnityEngine;
using UnityEditor;

namespace oddments
{
    [CustomEditor(typeof(Tables))]
    public class TablesInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("tableList"), true);
            if(GUILayout.Button("테이블 추가")){
                TableCreatorWindow.ShowUI();
            }
            serializedObject.ApplyModifiedProperties();
        }

        [MenuItem ("oddments/Create Tables _F4")]
        static void CreateExampleAsset ()
        {
            TableCreatorWindow.ShowUI();
        }
		[MenuItem("oddments/Resource Refresh _F5")]
		static void Refresh()
		{
            Debug.Log("Doing something with a Shortcut Key...");

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
		[MenuItem("oddments/Text Remover _F6")]
		static void CreateRemover()
		{
			LocalizeTextOverlapRemover.ShowUI();
		}
	}
}
