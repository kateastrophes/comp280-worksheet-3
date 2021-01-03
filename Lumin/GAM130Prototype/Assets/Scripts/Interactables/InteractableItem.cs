using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : Interactable {
    public bool m_debug = false;

    public PlayerInventory.items m_item;

    public GameObject m_parent = null;

    public UnityEvent m_pickupAction;

    public bool m_canInteract = true;
    public void enableInteract(bool interact = true) {
        m_canInteract = interact;
    }

    void Start() {
        base.Start();

        if (m_parent == null) m_parent = gameObject;
    }

    protected override void OnHighlight() {
        base.OnHighlight();

        if (m_debug) Debug.Log("highlight");
    }

    protected override void OnUnHighlight() {
        base.OnUnHighlight();

        if (m_debug) Debug.Log("un-highlight");
    }

    public override void OnPlayerInteract() {
        base.OnPlayerInteract();

        if (m_canInteract) {
            Debug.Log("interact");

            PlayerInventory.obj().pickup(m_item);

            m_pickupAction.Invoke();

            Destroy(m_parent);
        }
    }
}
