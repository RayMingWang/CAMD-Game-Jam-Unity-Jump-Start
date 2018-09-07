using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Sample_BlockSpawner : MonoBehaviour {
    
    
    public float HorizontalForce = 2.0f;
    public float ExtraGravity = 9.81f;
    public GameObject[] BuildingList;
    public Material[] ColorList;
    public float SpawnTime =0.8f;
    public GameObject BuildingBlock;
    public float LaunchSpeedMultiplier=1.5f;
    public float LaunchSpeedVerticalMultiplier = 0.5f;

    
    // Use this for initialization
    private Rigidbody _rb;
    
	void Start () {
        _rb = GetComponent<Rigidbody>();
	}



    private void FixedUpdate()
    {
        _rb.velocity += Vector3.down * ExtraGravity;

        _rb.velocity += Vector3.right * HorizontalForce * Input.GetAxis("Horizontal");


        if (Input.GetKey("space"))
        {
            if (BuildingBlock != null)
            {

                BuildingBlock.GetComponent<Rigidbody>().isKinematic = false;

                Vector3 launchSpeed = _rb.velocity * LaunchSpeedMultiplier;
                launchSpeed.y = _rb.velocity.y* LaunchSpeedVerticalMultiplier;
                BuildingBlock.GetComponent<Rigidbody>().velocity = launchSpeed;
                BuildingBlock.transform.parent = null;
                BuildingBlock.GetComponent<BoxCollider>().enabled = true;
                BuildingBlock.GetComponent<Sample_BuildingBlock>().released = true;

                BuildingBlock = null;
                StartCoroutine("SpawnBuildingBlock");

            }
        }
    }

    IEnumerator SpawnBuildingBlock()
    {

        yield return new WaitForSeconds(SpawnTime);
        
        BuildingBlock = Instantiate(BuildingList[Random.Range(0,BuildingList.Length)], transform);
        BuildingBlock.GetComponent<MeshRenderer>().material = ColorList[Random.Range(0, ColorList.Length)];
    }
}
