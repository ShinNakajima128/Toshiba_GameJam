using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移動関係の基底クラスRigidboyを持つ
/// </summary>
[RequireComponent(typeof(Rigidbody))]
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
    /// <summary>
    /// ゲーム停止時の処理
    /// </summary>
    public abstract void GameEnd();
}
