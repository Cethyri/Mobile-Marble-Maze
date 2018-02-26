using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {

    [SerializeField] Firework m_firework;
    [SerializeField] [Range(0.25f, 2.0f)] float m_timePerFirework = 1.0f;

    float m_fireworkTimer = 0.0f;
	
	// Update is called once per frame
	void Update () {
        m_fireworkTimer += Time.deltaTime;
        if (m_fireworkTimer >= m_timePerFirework)
        {
            m_fireworkTimer -= m_timePerFirework;
            Firework firework = Instantiate(m_firework, transform);

            firework.m_timeToExplode = Random.value + .5f;
            Destroy(firework.gameObject, firework.m_timeToExplode + 2.0f);

            firework.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 300, ForceMode.Force);
        }
    }
}
