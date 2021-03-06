using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            print("YYY key");
        }
        if (Input.GetKey(KeyCode.T))
        {
            print("TTT key");
        }
        if (Input.GetKey(KeyCode.P))
        {
            print("PPP key");
            playSoundEffect();
        }

        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(_speed * Time.deltaTime * direction);

        // Constrain vertical motion
        transform.position = new Vector3(transform.position.x,
                                 Mathf.Clamp(transform.position.y, -3.8f, 5.8f));

        // Wrap horizontal motion
        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void playSoundEffect()
    {
        explosionSound.Play();
    }
}
