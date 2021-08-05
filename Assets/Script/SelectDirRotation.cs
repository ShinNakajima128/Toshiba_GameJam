using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDirRotation : MonoBehaviour
{
    [SerializeField] Vector3 m_dir = Vector3.up;
    [SerializeField] float m_rotateSpeed = 5.0f;
    private void Update()
    {
        transform.Rotate(m_dir.normalized * m_rotateSpeed);
    }
}
