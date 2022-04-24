using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float health;
    public float speed;
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

        // 90 deg directional movement
        return;
        float directionY = inputVector.y;
        if (direction >0) {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (directionY > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (directionY < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Mouse direction movement
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.transform.position.z - transform.position.z));
        //mousePos.y = transform.position.y;
        //transform.LookAt(mousePos);

        //if isLit decrease health
        if (isLit)
        {
            health -= 100.0f * Time.deltaTime;
        }

        //if health below 0 die
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }


        /* Todo: Improve player movement 
         * Turning doesn't feel right, should be snappier
         */ 
        

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
        Debug.Log("Particle Collision" + other.name);
        ParticleSystem ps = trail.GetComponent<ParticleSystem>();
        ps.Stop();
        //TODO: refactor magic number to a variable or constant 
        ps.startLifetime += 2;
        ps.Play();


        if (other == trail)
        {
            //Debug.Log(other.name);
        }
    }
}
