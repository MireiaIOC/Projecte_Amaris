using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Header("SFX")] [SerializeField] AudioClip[] FootStepsClip;
    [SerializeField] AudioClip JumpSound;
    [SerializeField] AudioClip LandingSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootSteps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    private AudioClip GetRandomClip()
    {
        return FootStepsClip[UnityEngine.Random.Range(0, FootStepsClip.Length)];
    }

    private void JumpStart()
    {
        audioSource.PlayOneShot(JumpSound);
    }

    private void JumpEnd()
    {
        audioSource.PlayOneShot(LandingSound);
    }
}
