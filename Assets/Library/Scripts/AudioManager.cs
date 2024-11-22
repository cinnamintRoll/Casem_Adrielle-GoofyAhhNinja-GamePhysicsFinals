using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------------Audio Source---------------")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("---------------Audio Clips---------------")]
    public AudioClip background;
    public AudioClip gameBackground;
    public AudioClip badExplosion1;
    public AudioClip badExplosion2;
    public AudioClip badExplosion3;
    public AudioClip badExplosion4;
    public AudioClip explosion1;
    public AudioClip explosion2;
    public AudioClip explosion3;
    public AudioClip fall;
    public AudioClip restart;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayRandomBadExplosionSFX()
    {
        AudioClip[] explosionClips = { badExplosion1, badExplosion2, badExplosion3, badExplosion4 };
        AudioClip randomBadClip = explosionClips[Random.Range(0, explosionClips.Length)];
        PlaySFX(randomBadClip);
    }

    public void PlayRandomExplosionSFX()
    {
        AudioClip[] explosionClips = { explosion1, explosion2, explosion3 };
        AudioClip randomClip = explosionClips[Random.Range(0, explosionClips.Length)];
        PlaySFX(randomClip);
    }
}
