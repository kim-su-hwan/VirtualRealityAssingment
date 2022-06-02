using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PW
{
    public class FillTheCup : MonoBehaviour
    {
        [SerializeField]
        public ParticleSystem ps;

        void Start()
        {
        }
        void Update()
        {
            if (transform.rotation.eulerAngles[2] > 30 && ps.name=="water")
            {
                ps.Play();
            }
            else if (transform.rotation.eulerAngles[0] >35 && transform.rotation.eulerAngles[0] <325 && ps.name == "milk")
            {
                ps.Play();
            }
            else
            {
                ps.Stop();
            }
        }
    }
}