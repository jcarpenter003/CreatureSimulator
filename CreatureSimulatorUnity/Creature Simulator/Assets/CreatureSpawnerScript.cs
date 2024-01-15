using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawnerScript : MonoBehaviour
{
    public CreatureScript creature;

    private List<CreatureScript> creatures = new List<CreatureScript>();
    public int SpawnCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            SpawnCreature();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnCreature()
    {
        Debug.Log("Calling SpawnCreature()");
        var newCreature = Instantiate(creature, new Vector3(Random.Range(0, transform.position.x), Random.Range(0, transform.position.y), 0), transform.rotation);
        creatures.Add(newCreature);
    }
}
