using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using oddments;

public class GameRoot : Singleton<GameRoot>
{
    public UISystem UISystem { get; private set; } = new UISystem();

    private static bool InitTry = false;

    public static bool LoadComplete { get; private set; } = false;

    public static bool IsInit()
    {
        if (instance != null && !InitTry)
            Load();

        return instance != null;
    }

    private float deltaTime = 0f;

    public static void Load()
    {
        InitTry = true;
        Addressables.InstantiateAsync("GameRoot").Completed += (handle) =>
        {
            instance = handle.Result.GetComponent<GameRoot>();
        };
    }

    private void Update()
    {
        if (!LoadComplete)
            return;

        UISystem.Update();

        if(deltaTime >= 1f)
        {
            deltaTime -= 1f;
        }

        deltaTime += Time.deltaTime;


    }


    IEnumerator Start()
    {
        if(instance == null)
        {
            Load();
            Destroy(this.gameObject);
            yield break;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        yield return LoadGameData();
    }

    private IEnumerator LoadGameData()
    {
        yield return SoundPlayer.Create();
        yield return Config.Create();
        yield return Tables.Create();


        LoadComplete = true;
    }


}
