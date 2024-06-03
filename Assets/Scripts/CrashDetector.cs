using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;

            FindObjectOfType<PlayerController>().DisableControls();

            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Invoke("ReloadScene", delayTime);
        }
    }

    void ReloadScene()
    {
        crashEffect.Clear();
        SceneManager.LoadScene(0);
    }
}
