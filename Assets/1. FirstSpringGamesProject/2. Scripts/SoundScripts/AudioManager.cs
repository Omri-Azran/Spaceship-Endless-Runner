using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    AudioSource _AudioSource;
    [SerializeField] AudioClip OnHoverMusic, OnClickMusic, OnStrafeMusic, OnCollisionMusic, OnStartFlame;

    [HideInInspector]
    public bool CanPlayStrafeSound; 
    private void Awake()
    {
        //singleton - to get easier access to stuff and prevent audio looping by duplicates of this audio source
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
       
        DontDestroyOnLoad(Instance);
        
        
        
        _AudioSource = GetComponent<AudioSource>();


    }
    public void PlayOnStart()
    {
        _AudioSource.PlayOneShot(OnStartFlame);
    }
    public void PlayOnHover()
    {
        _AudioSource.PlayOneShot(OnHoverMusic);
    }
    public void PlayOnClick()
    {
        _AudioSource.PlayOneShot(OnClickMusic);
    }
    public void PlayOnStrafe()
    {
        if(CanPlayStrafeSound)
        {
            _AudioSource.PlayOneShot(OnStrafeMusic);
        }

        CanPlayStrafeSound = false;
    }
    public void PlayOnCollision()
    {
        _AudioSource.PlayOneShot(OnCollisionMusic);
    }
}
