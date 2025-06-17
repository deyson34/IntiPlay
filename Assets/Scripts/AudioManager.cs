using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;
    [Header("Música")]
    public AudioClip menuMusic;
    public AudioClip preGameMusic;
    public AudioClip gameplayMusic;
    [Header("SFX")]
    public AudioClip clickSound;
    public AudioClip clickSound2;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirMusica(AudioClip musica)
    {
        if (audioSource.clip == musica && audioSource.isPlaying)
            return;

        audioSource.clip = musica;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void DetenerMusica()
    {
        audioSource.Stop();
    }

    public void CambiarVolumen(float volumen)
    {
        audioSource.volume = volumen;
    }
}
