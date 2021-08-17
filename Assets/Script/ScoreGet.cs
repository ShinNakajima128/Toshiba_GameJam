using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerタグに衝突時スコアを加算し消滅
/// </summary>
public class ScoreGet : MonoBehaviour
{
    [Header("入手スコア")]
    [SerializeField] int m_score = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mouth")
        {
            GameManager.Instance.AddScore(m_score);
            EffectManager.Instance.PlayEffect(EffectType.ItemGet, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
