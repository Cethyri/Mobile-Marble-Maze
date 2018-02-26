using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] BallCamera m_camera;

    bool m_entered = false;

    public bool Entered
    {
        get
        {
            return m_entered;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            m_camera.m_increaseOffset = true;

            if (!m_entered)
            {
                m_entered = true;

                Color entered = Color.green;
                entered.a = 0.25f;

                GetComponent<MeshRenderer>().material.color = entered;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            m_camera.m_increaseOffset = false;
        }
    }
}
