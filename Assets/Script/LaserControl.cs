using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    Animator m_anime;
    bool m_shot;
    private void Start()
    {
        m_anime = GetComponent<Animator>();
        m_anime.Play("StandbyLaser");
    }
    public void ShotLaser(float time)
    {
        if (m_shot)
        {
            return;
        }
        m_anime.Play("StartLaser");
        StartCoroutine(LaserLife(time));
    }
    IEnumerator LaserLife(float time)
    {
        m_shot = true;
        yield return new WaitForSeconds(time);
        m_anime.Play("EndLaser");
        m_shot = false;
    }
}
