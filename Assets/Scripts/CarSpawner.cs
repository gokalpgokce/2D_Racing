using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] cars;
    public int carNo;
    public float maxPos;
    //public float delayTimer;
    //float timer;
    private float SpawnDuration = 1.4f;

    void Start()
    {
        //timer = delayTimer;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(DifficultRoutine());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnRoutine(){

        while(true){
            Vector3 carPos = new Vector3(Random.Range(-maxPos,maxPos),transform.position.y,transform.position.z);
            carNo = Random.Range(0,6);
            Instantiate(cars[carNo], carPos,transform.rotation);
            yield return new WaitForSeconds(SpawnDuration);
        }
    }

    IEnumerator DifficultRoutine(){
        while(true){
            yield return new WaitForSeconds(10.0f);
            SpawnDuration -= 0.2f;
            if (SpawnDuration <= 0.3f){
                SpawnDuration = 0.3f;
            }
        }
    }
}
