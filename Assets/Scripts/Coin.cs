using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int value;
    // Start is called before the first frame update
    void Start()
    {
        if (value != 0)
        {
            var valueFloat = Random.Range(1, 10);
            value = Mathf.Abs(valueFloat);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
