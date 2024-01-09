using NeuralNetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    public int Age { get; set; }
    public bool Gender { get; set; } // true for male, false for female
    public int Speed { get; set; }

    // Neural Network Info
    public Genome Genome { get; set; } = new Genome();
    public decimal OscillatorPeriod { get; set; } // TODO for future
    public NeuralNetwork neuralNetwork { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 postion = new Vector3 (0, 0, 0);
        this.gameObject.transform.position = Vector3.zero;
    }
}
