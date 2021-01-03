using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public Vector3 m_maskCentre = Vector3.zero;
    public Vector3 m_maskNormal = Vector3.forward;

    Vector3 m_startPos;

    Material m_material = null;

    void Start()
    {
        m_material = GetComponent<Renderer>().material;
        m_startPos = transform.position;

        setMask();
    }

    private void Update() {
        setMask();
    }

    void setMask() {
        m_material.SetVector("sliceCentre", m_startPos + m_maskCentre);
        m_material.SetVector("sliceNormal", m_maskNormal);
    }
}
