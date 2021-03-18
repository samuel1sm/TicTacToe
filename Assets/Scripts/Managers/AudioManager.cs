using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum Sound
{
    MusicOne,
    MusicTwo,
    ButtonClicked,
    NewItem,
    EndScreen,
    ScrollSound,
    SetIcon
}

[System.Serializable]
public class SoundAudioClip
{
    public Sound sound;
    public AudioClip audioClip;
    public float audioTime;
}


public class AudioManager : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] private float effectsVolume = 1;
    [Range(0f, 1f)] [SerializeField] private float musicVolume = 1;
    [SerializeField] private Sound[] musicList;
    public static AudioManager Instance;
    public SoundAudioClip[] audioClips;
    private static Dictionary<Sound, float> _soundTimerDictionary;
    private AudioSource _musicPlayerSource;
    private AudioManager _audioM;
    private int _nextMusic = 0;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        
        
        _soundTimerDictionary = new Dictionary<Sound, float>();

        var musicPlayer = new GameObject("LevelSound");
        musicPlayer.transform.parent = transform;
        _musicPlayerSource = musicPlayer.AddComponent<AudioSource>();
        _musicPlayerSource.volume = musicVolume;
        
      
        _musicPlayerSource.clip = GetAudioClip(musicList[_nextMusic]).audioClip;
        _nextMusic++;
        _musicPlayerSource.Play();
        
       
    }


    public void PlaySound(Sound sound)
    {
        SoundAudioClip sc = GetAudioClip(sound);
        if (CanPlaySound(sc))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(sc.audioClip, effectsVolume);
            //audioSource.PlayOneShot(sc.audioClip, efectsVolume);
            Destroy(soundGameObject, sc.audioClip.length);
        }
    }

    private static bool CanPlaySound(SoundAudioClip newSound)
    {
        switch (newSound.sound)
        {
            default:
                return true;
            // case Sound.ButtonClicked:
            //     if (_soundTimerDictionary.ContainsKey(newSound.sound))
            //     {
            //         float lastTimePlayed = _soundTimerDictionary[newSound.sound];
            //         float playerMoverTimerMax = newSound.audioTime;
            //
            //         if (lastTimePlayed + playerMoverTimerMax < Time.time)
            //         {
            //             _soundTimerDictionary[newSound.sound] = Time.time;
            //             return true;
            //         }
            //         else
            //         {
            //             return false;
            //         }
            //     }
            //     else
            //     {
            //         return true;
            //     }
        }
    }

    private SoundAudioClip GetAudioClip(Sound soundToPlay)
    {
        foreach (SoundAudioClip sc in audioClips)
        {
            if (sc.sound == soundToPlay)
            {
                return sc;
            }
        }

        Debug.LogError("Sound " + soundToPlay + " not found!");
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        _musicPlayerSource.volume = musicVolume;
        if(_musicPlayerSource.isPlaying) return;
        
        _musicPlayerSource.clip = GetAudioClip(musicList[_nextMusic]).audioClip;
        _musicPlayerSource.Play();
        _nextMusic = musicList.Length == _nextMusic + 1? 0 : _nextMusic + 1;
    }

    public void UpdateMusicVolume(float value)
    {
        musicVolume = value;
        _musicPlayerSource.volume = musicVolume;
    }
    
    public void UpdateEffectsVolume(float value)
    {
        effectsVolume = value;
    }
    
    public float GetMusicVolume()
    {
        return musicVolume;
    }
    
    public float GetEffectsVolume()
    {
        return effectsVolume;
    }
}