using System.Linq;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float[,] startPoint = {{-3.2f},{-3.15f}}; // where start cloning.
    [SerializeField] private float[,] endPoint = {{3.05f},{3.1f}}; // where end cloning.

    private float difference = 1.25f; // distance between spawnpoints.
[ContextMenu("Spawn Bombs")]
    void Start()
    {
        FillIn(); // function which fill in chart.
    }

    void FillIn(){
        for(float i = startPoint[0,0]; i <= endPoint[0,0]; i += difference){
            for(float j = startPoint[1,0]; j <= endPoint[1,0]; j += difference){
                Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count())], new Vector3(i,j,0), Quaternion.identity);      
            }
        }
    }

#if UNITY_EDITOR //code after this line will lose after compilation.

    void Awake(){
        if (Application.isPlaying){
        Destroyer();
        }
    }

    void Destroyer(){ // function destroy objects which appear in edit mode.
        GameObject[] obs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach(GameObject ob in obs){
            Destroy(ob);
        }

    }
#endif
}
