using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// オブジェクトを生成する
/// </summary>
public class SpawnMachine : MonoBehaviour
{
    [SerializeField] GameObject[] m_spawnObjects;
    public void Spawn(Vector3 pos)
    {
        int r = Random.Range(0, m_spawnObjects.Length);
        Instantiate(m_spawnObjects[r]).transform.position = pos;
    }
}
