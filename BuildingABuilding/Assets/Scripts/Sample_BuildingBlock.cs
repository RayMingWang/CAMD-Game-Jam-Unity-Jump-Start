using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_BuildingBlock : MonoBehaviour {
    public float horizontal_force = 2.0f;
    public float extra_gravity = 9.81f;

    public GameObject[] building_list;
    public Material[] color_list;
    public float spawn_time =0.8f;
    public GameObject building_block;
    public float launchspeed_multiplier=1.5f;
    public float launchspeed_vertical_multiplier = 0.5f;

    
    // Use this for initialization
    private Rigidbody rb;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
	}



    private void FixedUpdate()
    {
        rb.velocity += Vector3.down * extra_gravity;

        rb.velocity += Vector3.right * horizontal_force * Input.GetAxis("Horizontal");


        if (Input.GetKey("space"))
        {
            if (building_block != null)
            {

                building_block.GetComponent<Rigidbody>().isKinematic = false;

                Vector3 launch_speed = rb.velocity * launchspeed_multiplier;
                launch_speed.y = rb.velocity.y* launchspeed_vertical_multiplier;
                building_block.GetComponent<Rigidbody>().velocity = launch_speed;
                building_block.transform.parent = null;
                building_block.GetComponent<BoxCollider>().enabled = true;

                building_block = null;
                StartCoroutine("SpawnBuildingBlock");

            }
        }
    }

    IEnumerator SpawnBuildingBlock()
    {

        yield return new WaitForSeconds(spawn_time);
        
        building_block = Instantiate(building_list[Random.Range(0,building_list.Length)], transform);
        building_block.GetComponent<MeshRenderer>().material = color_list[Random.Range(0, color_list.Length)];
    }
}
