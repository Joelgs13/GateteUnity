using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorSierrasController : MonoBehaviour
{

    

    [SerializeField] public GameObject sierraSpawneable;
    [SerializeField] float velocidadSpawn = 2f;
    float minx = -2.5f;
    float maxx = 2.5f;

    //mio innovado
    int contador=0;
    float proporcionDelContadorFrenteATempo=10;
    void SpawnSierras(){
        print("inv");
        
        float randomX= Random.Range(minx,maxx);
        Vector2 spawnPos= new Vector2(randomX, transform.position.y);
        Instantiate(sierraSpawneable,spawnPos,Quaternion.identity);
        contador++;
        if (contador>=proporcionDelContadorFrenteATempo){
            velocidadSpawn=velocidadSpawn*0.9f;
            proporcionDelContadorFrenteATempo=proporcionDelContadorFrenteATempo*1.1f;
            contador=0;
            sierraSpawneable.GetComponent<Rigidbody2D>().gravityScale*=1.1f;
            CancelInvoke();
            StartSpawning();
        }
    }

    void StartSpawning(){
        InvokeRepeating("SpawnSierras",1f,velocidadSpawn);
    }

    public void StopSpawning() {
        CancelInvoke("SpawnSierras");
    }
    // Start is called before the first frame update
    void Start()
    {
        sierraSpawneable.GetComponent<Rigidbody2D>().gravityScale=1f;
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
