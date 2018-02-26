using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{

    public float m_timeToExplode = 5.0f;

    float m_explosionTimer = 0.0f;

    bool m_exploded = false;

    private void Update()
    {
        if (!m_exploded)
        {
            m_explosionTimer += Time.deltaTime;
            if (m_explosionTimer >= m_timeToExplode)
            {
                m_exploded = true;
                GetComponent<AudioSource>().Play();
                GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
