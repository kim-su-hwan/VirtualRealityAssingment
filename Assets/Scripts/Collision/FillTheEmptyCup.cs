using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PW
{
    [RequireComponent(typeof(ParticleSystem))]
    public class FillTheEmptyCup : MonoBehaviour
    {
        [SerializeField]
        public ParticleSystem ps;

        void Start()
        {
        }
        void Update()
        {
            if (transform.rotation.eulerAngles[2] > 30)
            {
                ps.Play();
            }
            else
            {
                ps.Stop();
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "HotCup")
            {

            }
        }
    }
}