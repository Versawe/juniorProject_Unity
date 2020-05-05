using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMoveForward : MonoBehaviour
{

    private float speed;

    Rigidbody rb;

    public GameObject userCar;

    private float randomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        userCar = GameObject.Find("carPrefabCTA");

        randomSpeed = Random.Range(750, 950);

        speed = randomSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(10,11);
        rb.velocity = transform.forward * speed * Time.deltaTime;

        if (transform.position.z > userCar.transform.position.z + 280) 
        {
            Destroy(gameObject);
        }
        if (transform.position.z < userCar.transform.position.z - 280)
        {
            Destroy(gameObject);
        }

    }
}
