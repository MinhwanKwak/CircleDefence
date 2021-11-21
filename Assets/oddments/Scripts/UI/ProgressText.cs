using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressText : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private string frontTextColorKey;
    [HideInInspector]
    [SerializeField]
    private string backTextColorKey;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    [ExecuteInEditMode]
    public void SetValue(string front, string back)
    {
        if( text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
            if( text == null)
            {
                Debug.LogError("ProgressText::SetValue  text is null");
                return;
            }
        }
        #if UNITY_EDITOR
        Color frontColor;
        Color backColor;
        if(!Application.isPlaying)
        {
            var loadData = UnityEditor.AssetDatabase.LoadAssetAtPath<Config>("Assets/Arts/Config/Config.asset");
            frontColor = loadData.GetTextColor(frontTextColorKey);
            backColor = loadData.GetTextColor(backTextColorKey);
        }
        else
        {
            frontColor = Config.Instance.GetTextColor(frontTextColorKey);
            backColor = Config.Instance.GetTextColor(backTextColorKey);
        }        
        #else
        var frontColor = Config.Instance.GetTextColor(frontTextColorKey);
        var backColor = Config.Instance.GetTextColor(backTextColorKey);
        #endif
        
        text.text = $"<color=#{ColorUtility.ToHtmlStringRGB(frontColor)}>{front}</color><color=#{ColorUtility.ToHtmlStringRGB(backColor)}>/{back}";
    }

    public void Test()
    {
        SetValue("0","1");
    }
}
