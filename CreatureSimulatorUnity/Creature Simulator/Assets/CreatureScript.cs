using NeuralNetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatureScript : MonoBehaviour
{
    public int Age { get; set; }
    public bool Gender { get; set; } // true for male, false for female
    private float Speed = 0.2f; // Speed of creature round to round

    // Neural Network Info
    public Genome Genome { get; set; } = new Genome();
    public decimal OscillatorPeriod { get; set; } // TODO for future
    public NeuralNetwork neuralNetwork { get; set; }

    // Frame Data
    private float timer = 0f;
    private int heightBound = Screen.height;
    private int widthBound = Screen.width;

    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f) // control speed of sim here
        {
            handleMovement();
            timer = 0f;
        }

    }

    private void handleMovement()
    {
        int num = Random.Range(1, 4);

        switch (num)
        {
            case 1:
                this.gameObject.transform.position += Vector3.up * Speed;
                break;
            case 2:
                this.gameObject.transform.position += Vector3.down * Speed;
                break;
            case 3:
                this.gameObject.transform.position += Vector3.left * Speed;
                break;
            case 4:
                this.gameObject.transform.position += Vector3.right * Speed;
                break;
            default:
                break;
        };




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name}");
    }
}
