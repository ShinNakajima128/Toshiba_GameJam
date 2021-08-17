using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [Header("レーザーゲージのアニメーター")]
    [SerializeField] Animator m_laserGaugeAnim = default;
    [SerializeField] float m_diminishGaugeTime = 5;
    public static bool isShooted = false;


    void Start()
    {
        m_laserGaugeAnim.enabled = false;
    }

    void Update()
    {
        if (GameManager.Instance.GetIsGaugeMaxed)
        {
            m_laserGaugeAnim.enabled = true;

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("レーザー発射");
                isShooted = true;
            }
        }

        if (isShooted && GameManager.Instance.LaserGauge > 0)
        {
            GameManager.Instance.LaserGauge -= Time.deltaTime * (GameManager.Instance.GetLaserMaxGauge /m_diminishGaugeTime);
            Debug.Log(GameManager.Instance.LaserGauge);
        }
        else if (GameManager.Instance.LaserGauge <= 0)
        {
            isShooted = false;
            m_laserGaugeAnim.enabled = false;
        }
    }
}
