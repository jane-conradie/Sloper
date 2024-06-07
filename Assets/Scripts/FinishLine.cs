using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // member variable
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    // member variable

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            finishEffect.Play();
            GetComponent<AudioSource>().Play();

            Invoke("ReloadScene", delayTime);
        }
    }

    void ReloadScene()
    {
        finishEffect.Clear();
        SceneManager.LoadScene(0);
    }
}
