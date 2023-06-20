using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePeople
{

    public class OTOAnimation : MonoBehaviour
    {
       
        private Transform pos;
        public Transform data;

        void FixedUpdate()
        {
            pos.position = new Vector3(data.position.x, data.position.y - 1.3f, data.position.z);
            //Debug.Log("fixing");
        }
        
       
    }
}
