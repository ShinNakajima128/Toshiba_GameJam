using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerに衝突時ダメージを与える
/// </summary>
public class HitDamage : MonoBehaviour
{
    [SerializeField] int m_damage = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundManager.Instance.PlaySeByName("2_damage");
            GameManager.Instance.Damage(m_damage);
            if (m_damage > 30)
            {
                EffectManager.Instance.PlayEffect(EffectType.ExplosionStar, this.transform.position);
            }
            else
            {
                EffectManager.Instance.PlayEffect(EffectType.Explosion, this.transform.position);
            }
            EffectManager.Instance.ViewText(m_damage, this.transform.position, Color.red);
            EffectManager.Instance.PlayShake();
            Destroy(this.gameObject);
        }
    }
}
