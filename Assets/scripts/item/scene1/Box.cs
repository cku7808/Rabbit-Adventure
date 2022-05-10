using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    Animator anim;
    public int num;
    public GameObject PrefabFloatingTxt;
    public GameObject box;
    int count = 0;
    AudioSource audioSource;
    public AudioClip boxSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("isClosed");
        num = Random.Range(-6, -1);
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            anim.SetTrigger("isOpen");

            if(count == 0)
            {
                count += 1;

                audioSource.PlayOneShot(boxSound);
                GameObject clone = Instantiate(PrefabFloatingTxt, box.transform.position, Quaternion.identity);
                Vector3 uiPosition = Camera.main.WorldToScreenPoint(transform.position);
                clone.transform.position = uiPosition;
                clone.transform.SetParent(box.transform);
                clone.GetComponent<floatingText>().text.text = num.ToString();
                timer.time += num;
            }
        }
    }
}
