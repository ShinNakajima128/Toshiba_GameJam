using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text m_score;
    // Start is called before the first frame update
    void Start()
    {
        m_score.text = GameManager.Instance.GetScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
