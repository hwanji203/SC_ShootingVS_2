using UnityEngine;

public class StepSound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float pitchRandomness = 0.05f;
    private float basePitch;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    private void PlayWithPitch(AudioClip clip)
    {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayStepSound()
    {
        PlayWithPitch(_audioClip);
    }
}
