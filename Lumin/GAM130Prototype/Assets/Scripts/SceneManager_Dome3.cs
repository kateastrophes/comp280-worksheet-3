using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_Dome3 : MonoBehaviour
{
    public AreaTrigger m_doorTrigger;
    public AreaTrigger m_levelTrigger;
    public Light m_light;

    void Start() {
        m_doorTrigger.m_enabled = false;
        m_levelTrigger.m_enabled = false;

        //set entrance level spawnpoint
        SpawnpointManager.s_spawn[(int)SpawnpointManager.scenes.ENTRANCE] = 3;

        if (PlayerInventory.obj().has(PlayerInventory.items.KEYCARD_GREEN) &&
            PlayerInventory.obj().has(PlayerInventory.items.KEYCARD_RED)
            ) {
            m_doorTrigger.m_enabled = true;
            m_levelTrigger.m_enabled = true;
            StartCoroutine(changeLight());
        }
    }

    IEnumerator changeLight() {
        yield return new WaitForSeconds(1f);

        m_light.enabled = false;

        yield return new WaitForSeconds(0.1f);

        m_light.enabled = true;
        yield return new WaitForSeconds(0.1f);

        m_light.enabled = false;
        yield return new WaitForSeconds(0.1f);

        m_light.enabled = true;
        yield return new WaitForSeconds(0.1f);

        m_light.enabled = false;
        yield return new WaitForSeconds(2f);

        m_light.enabled = true;
        yield return new WaitForSeconds(0.3f);

        m_light.enabled = false;
        yield return new WaitForSeconds(0.5f);

        m_light.enabled = true;
        m_light.color = Color.green;
    }
}
