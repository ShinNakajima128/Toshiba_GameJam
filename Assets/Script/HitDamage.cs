using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerに衝突時ダメージを与える
/// </summary>
public class HitDamage : MonoBehaviour
{
    [SerializeField] int m_damage = 100;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.Damage(m_damage);
            Destroy(this.gameObject);
        }
    }
}
