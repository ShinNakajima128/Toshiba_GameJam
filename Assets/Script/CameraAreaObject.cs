using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAreaObject : MonoBehaviour
{
    [SerializeField] GameObject m_activeObject;
    [SerializeField] GameObject m_inactiveObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CameraArea")
        {
            if (m_activeObject && m_inactiveObject)
            {
                m_activeObject.SetActive(false);
                m_inactiveObject.SetActive(true);
            }
        }
    }
}
