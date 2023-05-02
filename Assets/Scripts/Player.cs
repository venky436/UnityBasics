using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private int lives = 3;
    float timeGap = 0.5f;
    float canFire = -1f;

    private SpawnManager spawnManager;
    void Start()
    {
        transform.position = new Vector3(0,0,0);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if(spawnManager == null)
        {
            Debug.Log("Someting Wrong check");
        }
    }
    // Update is called once per frame
    void Update()
    {
        movement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > canFire ){
           Fire();
        }

    }

//   Laser Fire Logic
    void Fire(){
            canFire = Time.time + timeGap;
            Instantiate(laser,transform.position + new Vector3(0,0.8f,0),Quaternion.identity);
    }

//    Laser Movement Logic
    void movement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput,verticalInput,0) * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-4f,0),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-9.2f,9.2f),transform.position.y,0);

    }
    public void DamagePlayer()
    {
        lives--;
        if(lives < 1)
        {
            spawnManager.playerDeth();
            Destroy(this.gameObject);
        }
    }
}
