using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hitSound, failSound;

    static AudioSource audioSrc;

    void Start()
    {
        hitSound = Resources.Load<AudioClip>("Hit");
        failSound = Resources.Load<AudioClip>("Fail");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "Fail":
                audioSrc.PlayOneShot(failSound);
                break;
        }
    }
}
