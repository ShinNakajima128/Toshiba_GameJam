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
            EffectManager.Instance.PlayEffect(EffectType.Explosion, this.transform.position);
            EffectManager.Instance.PlayShake();
            Destroy(this.gameObject);
        }
    }
}
