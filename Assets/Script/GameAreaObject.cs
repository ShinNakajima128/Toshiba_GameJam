using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム画面外に出たら消える
/// </summary>
public class GameAreaObject : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameArea")
        {
            Destroy(this.gameObject);
        }
    }
}
