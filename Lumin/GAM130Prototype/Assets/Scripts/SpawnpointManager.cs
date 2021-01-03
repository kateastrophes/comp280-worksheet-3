using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointManager : MonoBehaviour
{
    static SpawnpointManager s_this;

    static public SpawnpointManager obj() { return s_this; }

    bool m_hasSetup = false;

    public void Setup() {
        if (!m_hasSetup) {
            //ensure singleton
            if (s_this != null) {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            s_this = this;
        }

        //spawn data
        s_spawn = new int[(int)scenes.NUM_SCENES];
        s_spawns = new spawnPoint[(int)scenes.NUM_SCENES, 4];

        s_spawns[(int)scenes.ENTRANCE, 0] = new spawnPoint();
        s_spawns[(int)scenes.ENTRANCE, 0].pos = new Vector3(-4.5f, 3.5f, 44.9f);
        s_spawns[(int)scenes.ENTRANCE, 0].rot = new Vector3(0f, -165.283f, 0f);
        s_spawns[(int)scenes.ENTRANCE, 1] = new spawnPoint();
        s_spawns[(int)scenes.ENTRANCE, 1].pos = new Vector3(17.75f, 3.5f, 35.31f);
        s_spawns[(int)scenes.ENTRANCE, 1].rot = new Vector3(0f, -84.13f, 0f);
        s_spawns[(int)scenes.ENTRANCE, 2] = new spawnPoint();
        s_spawns[(int)scenes.ENTRANCE, 2].pos = new Vector3(-31.58f, 3.5f, 33.3f);
        s_spawns[(int)scenes.ENTRANCE, 2].rot = new Vector3(0f, 96.675f, 0f);
        s_spawns[(int)scenes.ENTRANCE, 3] = new spawnPoint();
        s_spawns[(int)scenes.ENTRANCE, 3].pos = new Vector3(-5.879f, 3.5f, 8.1f);
        s_spawns[(int)scenes.ENTRANCE, 3].rot = new Vector3(0f, -3.74f, 0f);

        s_spawns[(int)scenes.ANDREA, 0] = new spawnPoint();
        s_spawns[(int)scenes.ANDREA, 0].pos = new Vector3(347f, 0.7f, 22.5f);
        s_spawns[(int)scenes.ANDREA, 0].rot = new Vector3(0.7f, -341f, 0f);

    }

    void Start()
    {
        Setup();
    }

    public enum scenes {
        ENTRANCE,
        LUCY,
        ANDREA,
        ROBBIE,
        ROBIN,

        NUM_SCENES
    }

    public struct spawnPoint {
        public Vector3 pos;
        public Vector3 rot;
    }

    static public int[] s_spawn;    
    static public spawnPoint[,] s_spawns;    

    public static void setSpawn(GameObject player, scenes scene) {
        spawnPoint spawn = s_spawns[(int)scene, s_spawn[(int)scene]];
        player.transform.position = spawn.pos;
        player.transform.Rotate(spawn.rot);
        //player.transform.Rotate(spawn.rot);
        //Debug.Log("rotation " + spawn.rot);
    }
}
