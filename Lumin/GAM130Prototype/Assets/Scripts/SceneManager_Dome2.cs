using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_Dome2 : MonoBehaviour
{
    public InteractableItem m_keycard;
    void Start()
    {
        if (PlayerInventory.obj().has(PlayerInventory.items.KEYCARD_RED)) {
            Destroy(m_keycard.m_parent);
        }

        //set entrance level spawnpoint
        SpawnpointManager.s_spawn[(int)SpawnpointManager.scenes.ENTRANCE] = 2;
    }
}
