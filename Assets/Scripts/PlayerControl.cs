using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public AudioClip shootSound, deadSound, healSound, hitSound;
    public Transform bulletPos;
    public GameObject bullet;
    public GameObject explotion;
    public Image healthImage;
    private float health = 100f;
    public GameControl gControl;
    private AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            aSource.PlayOneShot(shootSound, 1f);
            GameObject go = Instantiate(bullet,bulletPos.position,bulletPos.rotation) as GameObject;
            GameObject goExp = Instantiate(explotion, bulletPos.position, bulletPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = bulletPos.transform.forward * 10f;
            Destroy(go.gameObject,2f);
            Destroy(goExp.gameObject, 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("zombie"))
        {
            aSource.PlayOneShot(hitSound, 1f);
            health -= 10;
            float x = health / 100f;
            healthImage.fillAmount = x;
            healthImage.color = Color.Lerp(Color.red,Color.green,x);

            if (health<=0)
            {
                aSource.PlayOneShot(deadSound,1f);
                gControl.gameEnd();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("heart"))
        {
            aSource.PlayOneShot(healSound, 1f);
            health += 20;
            float x = health / 100f;
            healthImage.fillAmount = x;
            healthImage.color = Color.Lerp(Color.red, Color.green, x);
            Destroy(other.gameObject);

        }
    }
}
