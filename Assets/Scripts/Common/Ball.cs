using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    [SerializeField] Text m_goalsDisplay = null;
    [SerializeField] Text m_timeDisplay = null;
    [SerializeField] GameObject m_worldCenter = null;
    [SerializeField] Goal[] m_goals = null;

    [SerializeField] Game m_game = null;

    [SerializeField] float m_time = 0.0f;

    Rigidbody m_rigidbody;

    bool m_won = false;

    public Rigidbody Rigidbody
    {
        get
        {
            return m_rigidbody;
        }
    }

    // Use this for initialization
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        transform.position = m_worldCenter.transform.position + Random.onUnitSphere * 45;
    }

    void Update()
    {
        int goalsCompleted = 0;
        foreach (Goal goal in m_goals)
        {
            if (goal.Entered)
            {
                goalsCompleted++;
            }
        }

        m_goalsDisplay.text = goalsCompleted + "/" + m_goals.Length;

        if (goalsCompleted == m_goals.Length && !m_won)
        {
            m_game.Win();
            m_won = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_won)
        {
            m_time = Time.time;
            m_timeDisplay.text = (Mathf.RoundToInt(m_time * 10) / 10.0f).ToString();
        }

#if UNITY_ANDROID
        Vector3 force = new Vector3(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z) + Vector3.forward;
#else
        Vector3 force = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1.0f) + Vector3.forward;
#endif


        float movement = Mathf.Sqrt(force.x * force.x + force.y * force.y);
        force.x /= movement > 1 ? movement : 1.0f;
        force.y /= movement > 1 ? movement : 1.0f;

        force = Quaternion.LookRotation(m_worldCenter.transform.position - transform.position) * force;

        Rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public void Win()
    {

    }
}
