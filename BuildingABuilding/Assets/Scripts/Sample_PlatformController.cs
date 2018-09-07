using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     
     public class Sample_PlatformController : MonoBehaviour
     {
     
        public float speed = 10f;
  

        // Update is called once per frame
        private void Update()
        {
            transform.position = transform.position + Vector3.up * speed * Input.GetAxis("Vertical");
    
        }
}
