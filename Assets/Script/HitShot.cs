using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitShot : MonoBehaviour
{
    [Header("弾に耐えられる耐久度")]
    [SerializeField] int m_hp = 0;
    int m_currentHp;
    private void Start()
    {
        m_currentHp = m_hp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            Destroy(other.gameObject);
            HitDamage(1);
        }
    }
    public void HitDamage(int damage)
    {
        m_currentHp -= damage;
        if (m_currentHp <= 0)
        {
            EffectManager.Instance.PlayEffect(EffectType.Explosion, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
