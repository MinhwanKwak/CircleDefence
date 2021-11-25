using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using oddments;

public class GameRoot : MonoBehaviour
{
    public UISystem UISystem { get; private set; } = new UISystem();
    public UserDataSystem UserDataSystem { get; private set; } = new UserDataSystem();

    public static GameRoot Instance;

    private static bool InitTry = false;

    public static bool LoadComplete { get; private set; } = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        UserDataSystem.Create();
        UserDataSystem.LoadUserData();
    }



#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        UserDataSystem.SaveUserData();
    }
#endif

    //IEnumerator Start()
    //{


    //    if (instance == null)
    //    {
    //        Destroy(this.gameObject);
    //        yield break;
    //    }

    //    Screen.sleepTimeout = SleepTimeout.NeverSleep;

    //    yield return LoadGameData();
    //}

    private IEnumerator LoadGameData()
    {
        yield return SoundPlayer.Create();
        yield return Config.Create();
        yield return Tables.Create();


        LoadComplete = true;
    }


}
