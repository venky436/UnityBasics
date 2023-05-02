using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 7.5){
            transform.position = new Vector3(transform.position.x, transform.position.y + 1 * speed * Time.deltaTime,transform.position.z);
        }else{
            Destroy(gameObject);
        }
        
    }
}
