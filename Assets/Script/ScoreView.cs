using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnGetScore += ViewScore;
    }
    private void OnDisable()
    {
        EventManager.OnGetScore -= ViewScore;
    }
    void ViewScore(int score)
    {
        float rX = Random.Range(-0.5f, 0.6f);
        float rY = Random.Range(-0.5f, 0.6f);
        EffectManager.Instance.ViewText(score, this.transform.position + new Vector3(rX,rY,0), Color.white);
    }
}
