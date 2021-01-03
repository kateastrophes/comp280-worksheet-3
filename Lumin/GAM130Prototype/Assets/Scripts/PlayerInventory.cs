using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    static PlayerInventory s_this;

    public static PlayerInventory obj() {
        return s_this;
    }

    bool m_hasSetup = false;

    public void Setup() {
        if (!m_hasSetup) {
            m_hasSetup = true;

            //ensure singleton
            if (s_this != null) {
                Destroy(gameObject);
                return;
            }            

            DontDestroyOnLoad(gameObject);

            s_this = this;


            //default to false = start empty inventory
            m_items = new bool[(int)items.ITEMS_LENGTH];
        }
    }

    void Start()
    {
        Setup();
    }

    public enum items {
        KEYCARD_GREEN,
        KEYCARD_RED,
        GASMASK,

        ITEMS_LENGTH
    }

    public bool[] m_items;

    public void pickup(items item) {
        m_items[(int)item] = true;
    }
    public bool drop(items item) {
        bool has = m_items[(int)item];
        m_items[(int)item] = false;
        return has;
    }
    public bool has(items item) {
        return m_items[(int)item];
    }
}
