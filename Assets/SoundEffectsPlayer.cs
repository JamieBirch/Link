using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public void playSound(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.Play();
    }
}