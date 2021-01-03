using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_this;
    public static GameManager obj() {
        return s_this;
    }

    //'global' objects
    public GameObject m_player = null;
    public static PlayerCharacterController s_playerCharacterController;

    public SpawnpointManager.scenes m_scene = SpawnpointManager.scenes.NUM_SCENES;

    void Start()
    {
        //ensure singleton
        if (s_this != null) {
            Destroy(gameObject);
            return;
        }
        s_this = this;

        //get global objects
        if(m_player == null) m_player = GameObject.Find("Player");
        if (m_player != null) s_playerCharacterController = m_player.GetComponent<PlayerCharacterController>();

        //set spawn point
        if(m_scene != SpawnpointManager.scenes.NUM_SCENES) SpawnpointManager.setSpawn(m_player, m_scene);
    }    
}
