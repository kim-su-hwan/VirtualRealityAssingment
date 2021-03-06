using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PW
{
    public class FillTheCup : MonoBehaviour
    {
        [SerializeField]
        public ParticleSystem ps;
        private float time;

        void Start()
        {
            time = 0;
        }
        void Update()
        {
            if (((transform.rotation.eulerAngles[0] >35 && transform.rotation.eulerAngles[0] <325) || (transform.rotation.eulerAngles[2] > 35 && transform.rotation.eulerAngles[2] < 325)) && (ps.name == "milk" || ps.name == "sprite" || ps.name == "mocha" || ps.name == "vanilla" || ps.name == "water"))
            {
                ps.Play();
                time += Time.deltaTime;
            }
            else
            {
                ps.Stop();
            }
            // Particle 플레이 타임이 30초가 넘어가면 오브젝트 삭제
            if(time >= 30.0)
            {
                //Destroy(transform.gameObject);
            }
        }
    }
}