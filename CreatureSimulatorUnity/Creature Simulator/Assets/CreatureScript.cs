using NeuralNetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatureScript : MonoBehaviour
{
    public int Age { get; set; }
    public bool Gender { get; set; } // true for male, false for female
    public float Speed = 3f;

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

        //Camera.main.WorldToScreenPoint(transform.position);
        if (timer >= 1.0f)
        {
            handleMovement();
            timer = 0f;
        }

    }

    private void handleMovement()
    {
        var screenX = Random.Range(-(widthBound / 2), widthBound);
        var screenY = Random.Range(-(heightBound / 2), heightBound);

        //Vector3 screenPoints = new Vector3(screenY, screenX, 0);
        //Vector3.Up
        //Vector3 position = Camera.main.ScreenToViewportPoint(screenPoints);

        int num = Random.Range(1, 4);

        switch (num)
        {
            case 1:
                this.gameObject.transform.position += Vector3.up * Speed;
                break;
            case 2:
                //this.gameObject.transform.position += Vector3.down * Speed;
                break;
            case 3:
                //this.gameObject.transform.position += Vector3.left * Speed;
                break;
            case 4:
                //this.gameObject.transform.position += Vector3.right * Speed;
                break;
            default:
                break;
        };




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name}");
        //Debug.Log($"X: {collision.gameObject.transform.position.x}- Y: {collision.gameObject.transform.position.y}- Z: {collision.gameObject.transform.position.z}");

        if (collision.gameObject.name.ToLower().StartsWith("top"))
        {
            //var currentPosition = this.gameObject.transform.position;
            //var boundaryPosition = collision.gameObject.transform.position;

            //Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y - (Speed / 2), currentPosition.z);

            //this.gameObject.transform.position = newPosition;
        }
        else if (collision.gameObject.name.ToLower().StartsWith("bottom"))
        {

        }
        else if (collision.gameObject.name.ToLower().StartsWith("left"))
        {

        }
        else if (collision.gameObject.name.ToLower().StartsWith("right"))
        {

        }

        //this.gameObject.transform.position -= 
    }
}
