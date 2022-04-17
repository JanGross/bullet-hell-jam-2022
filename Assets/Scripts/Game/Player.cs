using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float health;
    public float speed;
    public float trailLength;
    public GameObject trail;
    public float rotationSpeed;
    public float direction;
    public List<ParticleCollisionEvent> collisionEvents;
    public bool isLit;

    public Camera camera;
    

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }


    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        direction = inputVector.x;        
        
    }


    // Update is called once per frame
    void Update()
    {

        //if isLit decrease health
        if (isLit)
        {
            health -= 100.0f * Time.deltaTime;
            Debug.Log("Health: " + health);
        }

        //move player forward
        transform.position += transform.forward * speed * Time.deltaTime;
        //rotate based on direction
        transform.Rotate(0, direction * rotationSpeed * 2 * Time.deltaTime, 0);

        float horzExtent = camera.orthographicSize * Screen.width / Screen.height;
        float vertExtent = camera.orthographicSize;

        if (transform.position.z > vertExtent)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -vertExtent);
        }
        else if (transform.position.z < -vertExtent)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, vertExtent);
        }
        
        if (transform.position.x > horzExtent)
        {
            transform.position = new Vector3(-horzExtent, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horzExtent)
        {
            transform.position = new Vector3(horzExtent, transform.position.y, transform.position.z);
        }
    }

    public void DecreaseTrail(float val)
    {
        //Decreate trail length (for pickups)
    }

    public void BulletHit()
    {
        //Increate trail length
    }

    
    private void OnParticleCollision(GameObject other)
    {
        if (other == trail)
        {
            //Debug.Log(other.name);
        }
    }
}
