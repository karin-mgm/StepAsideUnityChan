using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ItemGenerator : MonoBehaviour
{

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    public int buffer = 0;
    private float posRange = 3f;
    private GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        buffer = 100;
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {

        buffer--;
        if (buffer <= 0)
        {
            for (int i = 10; i < (unitychan.transform.position.z )+ 70; i += 15)
            {

                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int item = Random.Range(1, 11);
                        int offsetZ = Random.Range(-5, 6);
                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }
            }
            buffer = 700;
        }
    }
}

