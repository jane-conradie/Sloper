using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;


    private void OnCollisionEnter2D(Collision2D other)
    {
        // check first if Rod is colliding with floor
        if (other.gameObject.tag == "Ground")
        {
            // while Rod touches floor - show dust
            dustEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // check first if Rod has stopped colliding with floor
        if (other.gameObject.tag == "Ground")
        {
            // while Rod is doing tricks and turns in air - do not show dust
            dustEffect.Stop();
        }
    }
}
