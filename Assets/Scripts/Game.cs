using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] GameObject m_maze = null;
    [SerializeField] GameObject m_winnerPlanet = null;
    [SerializeField] Fireworks m_fireWorks = null;

    bool m_shrinkMaze = false;

    // Use this for initialization
    void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_shrinkMaze)
        {
            m_maze.transform.localScale *= 0.95f;
            if (m_maze.transform.localScale.magnitude < .01f)
            {
                m_shrinkMaze = false;
                m_maze.SetActive(false);
            }
        }
    }

    public void Win()
    {
        m_shrinkMaze = true;
        //m_maze.SetActive(false);
        m_winnerPlanet.SetActive(true);
        m_fireWorks.gameObject.SetActive(true);
    }
}
