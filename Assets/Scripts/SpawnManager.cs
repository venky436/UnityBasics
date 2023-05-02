using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enimy;
    [SerializeField]
    private GameObject enimyContainer;
    private IEnumerator coroutine;

    private bool stopCreatingEnimy = false;
    void Start()
    {
        coroutine = WaitAndCreateEnimy(4f);
        StartCoroutine(coroutine);
    }

    void Update()
    {
        
    }
    private IEnumerator WaitAndCreateEnimy(float waitTime)
    {
        while (stopCreatingEnimy == false)
        {
          GameObject newEnimy =  Instantiate(enimy,new Vector3(Random.Range(-9.6f, 9.6f), 7.5f, 0), Quaternion.identity);
            newEnimy.transform.parent = enimyContainer.transform;
            yield return new WaitForSeconds(waitTime);
        }

    }

    public void playerDeth()
    {
        stopCreatingEnimy = true;

    }
}
