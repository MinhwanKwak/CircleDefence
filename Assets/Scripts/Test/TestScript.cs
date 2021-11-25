using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{

    [SerializeField]
    private Text HpText;

    [SerializeField]
    private Text MpText;

    [SerializeField]
    private Button OnClickLoadButton;

    [SerializeField]
    private Button TestDataButton;

    private void Awake()
    {
        OnClickLoadButton.onClick.AddListener(OnClick);
        TestDataButton.onClick.AddListener(TestData);
    }

    private void Start()
    {
        var userdata = GameRoot.Instance.UserDataSystem.userdata;
        HpText.text = userdata.health.ToString();
        MpText.text = userdata.ExchangeDatas[0].ToString();
    }

    public void TestData()
    {
        var userdata = GameRoot.Instance.UserDataSystem.userdata;
        userdata.health = 25;
        userdata.ExchangeDatas[0] = 17;
        HpText.text = userdata.health.ToString();
        MpText.text = userdata.ExchangeDatas[0].ToString();


        GameRoot.Instance.UserDataSystem.SaveUserData();
    }
    
    public void OnClick()
    {
        var userdata = GameRoot.Instance.UserDataSystem.userdata;
        HpText.text = userdata.health.ToString();
        MpText.text = userdata.ExchangeDatas[0].ToString();

    }

}
