using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oddments;

public class SoundPlayer : SingletonScriptableObject<SoundPlayer>, ILoader
{
    [System.Serializable]
    public class SoundData
    {
        public string soundKey;
        public AudioClip audioData;
    }
    [SerializeField]
    private List<SoundData> soundDatas = new List<SoundData>();
    private Dictionary<string, AudioClip> soundDataDic = new Dictionary<string, AudioClip>();
    public List<SoundData> SoundDataList { get { return soundDatas; } }

    private List<AudioSource> cachedSources = new List<AudioSource>();
    private AudioSource BGMSource = null;
    private AudioClip recoveryBGMClip = null;
    private Transform Root = null;


    private bool soundon = true;
    public AudioClip GetSoundData(string key)
    {
        if(soundDataDic.ContainsKey(key))
            return soundDataDic[key];
        
        return null;
    }

    public void SetRoot(Transform _root)
    {
        Root = _root;
    }

    public void PlaySound(string key)
    {
        if (!soundon) return;

        var audio = GetAudioSource();
        audio.loop = false;
        audio.PlayOneShot(GetSoundData(key));
        
    }

    public void PlayBGM(string key, bool recovery = false)
    {
        if(BGMSource == null)
        {
            BGMSource = new GameObject("sound entity").AddComponent<AudioSource>();
            BGMSource.transform.SetParent(Root);
        }

        BGMSource.loop = true;
        var clip = GetSoundData(key);
        if(recovery)
            recoveryBGMClip = clip;
        BGMSource.clip = clip;
        BGMSource.Play();
    }

    public void RecoveryBGM()
    {
        BGMSource.clip = recoveryBGMClip;
        BGMSource.Play();
    }

    public void BgmSwitch(bool value)
    {
        if(BGMSource != null)
            BGMSource.mute = !value;
    }
    public void EffectSwitch(bool value)
    {
        soundon = value;
    }

    private AudioSource GetAudioSource()
    {
        AudioSource audio = null;

        foreach(var source in cachedSources)
        {
            if(!source.isPlaying)
            {
                audio = source;
                return audio;
            }
        }
    
        if(audio == null)
        {
            audio = new GameObject("sound entity").AddComponent<AudioSource>();
            cachedSources.Add(audio);
            audio.transform.SetParent(Root);
        }

        return audio;
    }
    
    public void Load()
    {
        cachedSources.Clear();
        soundDataDic.Clear();
        foreach(var sd in soundDatas)
        {
            soundDataDic.Add(sd.soundKey, sd.audioData);
        }
    }
}
