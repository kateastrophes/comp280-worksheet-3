using UnityEngine;

public class LightCycle : MonoBehaviour
{

    [SerializeField]
    public float secondsInDay;
    [Range(0, 1)]
    public float currentTime = 0f;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, (60f / secondsInDay) * Time.deltaTime);
        transform.LookAt(Vector3.zero);

    }


}