using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioSource SFXSource;

    [Header("----- Audio Clip -----")]
    public AudioClip background;
    public AudioClip Coin;
    public AudioClip Damage;
    public AudioClip HealthPotion;
    public AudioClip PermBuff;
    public AudioClip Arrow;
    public AudioClip UIClick;
    public AudioClip Enemy;
    public AudioClip Swing;
    public AudioClip Chest;
    public AudioClip Lucky;
    public AudioClip Unlucky;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
