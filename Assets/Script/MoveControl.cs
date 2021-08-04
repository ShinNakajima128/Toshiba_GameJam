using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移動関係の基底クラス
/// </summary>
public abstract class MoveControl : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnGameEnd += GameEnd;
    }
    private void OnDisable()
    {
        EventManager.OnGameEnd -= GameEnd;
    }

    public abstract void GameEnd();
}
