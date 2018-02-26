using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 20.0f)] float m_distance = 20.0f;
    [SerializeField] [Range(1.0f, 90.0f)] float m_pitch = 80.0f;
    [SerializeField] [Range(0.1f, 10.0f)] float m_response = 5.0f;
    [SerializeField] Ball m_target = null;
    [SerializeField] GameObject m_worldCenter = null;

    public bool m_increaseOffset = false;

    void FixedUpdate()
    {
        Quaternion view = Quaternion.Euler(m_pitch, 0.0f, 0.0f);
        view = Quaternion.LookRotation(m_worldCenter.transform.position - m_target.transform.position);

        //Debug.DrawLine(m_target.transform.position, m_worldCenter.transform.position);

        Vector3 position = m_target.transform.position;
        Vector3 offset = view * (Vector3.back * m_distance);

        if (m_increaseOffset)
        {
            offset *= 5;
        }

        Vector3 targetPosition = Vector3.Lerp(transform.position, position + offset, Time.deltaTime * m_response);
        Quaternion targetRotation = Quaternion.Lerp(transform.rotation, view, Time.deltaTime * m_response);

        transform.position = targetPosition;
        transform.rotation = targetRotation;
	}
}
