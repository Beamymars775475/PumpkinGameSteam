using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using System.Data.Common;


public class PumpkinSpawnerDebugEditor : MonoBehaviour
{

}

#if UNITY_EDITOR
[CustomEditor(typeof(PumpkinSpawnerDebugEditor))]
public class PumpkinSpawnerDebugEditorEditor : Editor
{
    
    public GameObject[] pumpPrefab;
    public float minY;
    public float maxY;
    private float WallToSpawnCoordinates;
    bool canBeSpawn;

    public float CoordinatesLeftWallPumpkin;
    public float CoordinatesRightWallPumpkin;

    public override void OnInspectorGUI()
    {
        var pumpkinSpawnerDebug = (PumpkinSpawnerDebugEditor)target;
        if (pumpkinSpawnerDebug == null) return;

        if(GUILayout.Button("Build Pump"))
        {

            var wanted = Random.Range(minY, maxY);
            var WallPosition = Random.Range(0, 2);
            int prefabRotation;
            //Les cos du murs
            
            if(WallPosition == 0)
            {
                WallToSpawnCoordinates = CoordinatesLeftWallPumpkin;
                prefabRotation = -90;
            }
            else
            {
                WallToSpawnCoordinates = CoordinatesRightWallPumpkin;
                prefabRotation = 90;
            }

            var position = new Vector3(WallToSpawnCoordinates, wanted);
            GameObject prefab = Instantiate(pumpPrefab[0], position, Quaternion.identity);
            prefab.transform.rotation = Quaternion.Euler(new Vector3(0,0,prefabRotation));

        }
    }
}
#endif
