using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CommonCreator 
{
    [MenuItem("GameObject/Treeplla Common UI/Dim", false, 8)]
    public static void CommonDim()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Dim.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }


    [MenuItem("GameObject/Treeplla Common UI/BtnClose", false, 8)]
    public static void CommonBtnClose()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Btn_Close.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

    [MenuItem("GameObject/Treeplla Common UI/BtnIcon", false, 8)]
    public static void CommonBtnIcon()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Btn_Icon.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    [MenuItem("GameObject/Treeplla Common UI/BtnIconTMP", false, 8)]
    public static void CommonBtnIconTMP()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Btn_IconTMP.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    [MenuItem("GameObject/Treeplla Common UI/BtnTMP", false, 8)]
    public static void CommonBtnTMP()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Btn_TMP.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }


    [MenuItem("GameObject/Treeplla Common UI/Popup", false, 8)]
    public static void CommonPopup()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Popup.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    
    [MenuItem("GameObject/Treeplla Common UI/Progress", false, 8)]
    public static void CommonProgress()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Progress.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }
    
    [MenuItem("GameObject/Treeplla Common UI/Reddot", false, 8)]
    public static void CommonReddot()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Reddot.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    [MenuItem("GameObject/Treeplla Common UI/TMP", false, 8)]
    public static void CommonTMP()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Text.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    [MenuItem("GameObject/Treeplla Common UI/TMP_SprtieRenderer", false, 8)]
    public static void CommonTMPSpriteRenderer()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/Text_SprtieRenderer.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    [MenuItem("GameObject/Treeplla Common UI/ToggleBtn", false, 8)]
    public static void CommonToggleBtn()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/ToggleBtn.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }

    [MenuItem("GameObject/Treeplla Common UI/IconTextInfo", false, 8)]
    public static void CommonIconTextInfo()
    {
        var loadResource = 
            AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Arts/Prefabs/Common/IconTextInfo.prefab");
        
        var obj = PrefabUtility.InstantiatePrefab(loadResource) as GameObject;
        if(Selection.activeGameObject != null)
            obj.transform.SetParent(Selection.activeGameObject.transform, false);        
    }
}
