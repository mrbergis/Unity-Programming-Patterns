using UnityEngine;

public class AmbientAudioPlayerBehaviour : MonoBehaviour
{

    private AmbientAudioPlayerBehaviour _instance = null;
    
    private void Awake() {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if( _instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    public void FadeNewMusic(AudioClip clip)
    {
        
    }
}