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

    // Start is called before the first frame update
    void Start()
    {
        //timer = delayTimer;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(DifficultRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        // burda update kullanarak spawn suresunu 1 sn yapiyorduk. alttaki SpawnRoutine fonksiyonuyla bunu yapabiliyoruz.
        //timer -= Time.deltaTime;
        //if(timer <= 0){
        //    Vector3 carPos = new Vector3(Random.Range(-maxPos,maxPos),transform.position.y,transform.position.z);
        //    carNo = Random.Range(0,6);
        //    Instantiate(cars[carNo], carPos,transform.rotation);
        //    timer = delayTimer;
        //}
    }

    IEnumerator SpawnRoutine(){

        while(true){
            Vector3 carPos = new Vector3(Random.Range(-maxPos,maxPos),transform.position.y,transform.position.z);
            carNo = Random.Range(0,6);
            Instantiate(cars[carNo], carPos,transform.rotation);
            yield return new WaitForSeconds(SpawnDuration);
            //Debug.Log("2");
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
