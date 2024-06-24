using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{
    private Animator animator;

    private AudioSource audioSource;

    public static bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
        //DestroySelf();
        //Debug.Log("Enter");
        audioSource.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

    private void DestroySelf()
    {
        isClear = true;
        Destroy(gameObject);
    }
}
