using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public Light m_light;

    public float m_intensityHigh = 10f;
    public float m_intensityLow = 1f;
    public int m_flashes = 1;
    public float m_flashLengthUp = 1f;    
    public float m_flashLengthDown = 1f;
    public float m_flashSpeedUp = -1f;
    public float m_flashSpeedDown = -1f;
    public float m_flashPause = 0f;
    public float m_pauseShort = 1;
    public float m_pauseLong = 3f;

    bool m_isFlashing = false;

    void Start()
    {
        if (m_light == null) m_light = GetComponent<Light>();
        StartCoroutine(flash());
    }

    public void TurnOn() {
        if(!m_isFlashing) StartCoroutine(flash());
    }
    public void TurnOff() {
        StopAllCoroutines();
        m_light.intensity = m_intensityLow;
        m_isFlashing = false;
    }

    IEnumerator flash() {
        m_isFlashing = true;

        m_light.intensity = m_intensityLow;

        float start = 0f;
        float t = 0f;
        while (true) {            
            for(int i = 0; i < m_flashes; i++) {
                //flash up
                start = Time.time;
                t = (Time.time - start) / m_flashLengthUp;
                while(t < 1f) {
                    if (m_flashSpeedUp < 0f) m_light.intensity = Mathf.Lerp(m_intensityLow, m_intensityHigh, t);
                    else m_light.intensity = Mathf.Lerp(m_light.intensity, m_intensityHigh, Time.deltaTime * m_flashSpeedUp);
                    yield return new WaitForEndOfFrame();
                    t = (Time.time - start) / m_flashLengthUp;
                }
                m_light.intensity = m_intensityHigh;
                //pause at top
                yield return new WaitForSeconds(m_flashPause);
                //flash down
                start = Time.time;
                t = (Time.time - start) / m_flashLengthDown;
                while (t < 1f) {
                    if (m_flashSpeedDown < 0f) m_light.intensity = Mathf.Lerp(m_intensityHigh, m_intensityLow, t);
                    else m_light.intensity = Mathf.Lerp(m_light.intensity, m_intensityLow, Time.deltaTime * m_flashSpeedDown);
                    yield return new WaitForEndOfFrame();
                    t = (Time.time - start) / m_flashLengthDown;
                }
                m_light.intensity = m_intensityLow;
                //pause between flashes
                yield return new WaitForSeconds(m_pauseShort);
            }
            //pause between sets
            yield return new WaitForSeconds(m_pauseLong);
        }
    }
}
