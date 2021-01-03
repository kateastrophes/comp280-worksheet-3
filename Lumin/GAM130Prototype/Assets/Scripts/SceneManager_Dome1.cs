using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_Dome1 : MonoBehaviour
{
    public InteractableItem m_keycard;

    public LogicGate m_switch;

    void Start()
    {
        SpawnpointManager.s_spawn[(int)SpawnpointManager.scenes.ENTRANCE] = 1;

        if (PlayerInventory.obj().has(PlayerInventory.items.KEYCARD_GREEN)) {            
            m_switch.invoke();
            Destroy(m_keycard.m_parent);
        }
    }

    public void enableKeycard() {
        m_keycard.m_canInteract = true;
    }
}
