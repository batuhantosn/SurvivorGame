using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieMove : MonoBehaviour
{
    public GameObject heart;
    private GameObject player;
    private int zombieHealth = 3;
    private int zombieScore = 100;
    private float distance;
    private AudioSource aSource;
    private bool zombiedead = false;

    private GameControl gControl;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        player = GameObject.Find("FPSController");
        gControl = GameObject.Find("_Scripts").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        distance = Vector3.Distance(transform.position,player.transform.position);

        if (distance < 5f)
        {
            if (!aSource.isPlaying)
            aSource.Play();
            if (!zombiedead)
            {
                GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
            }
            
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();
            GetComponentInChildren<Animation>().Play("Zombie_Walk_01");
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("bullet"))
        {
            zombieHealth--;


            if (zombieHealth == 0)
            {
                zombiedead = true;
                gControl.scoreInc(zombieScore);
                Instantiate(heart,transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject,1.6f);
            }
        }
    }
}
