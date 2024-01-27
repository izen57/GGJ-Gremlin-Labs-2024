using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityCheck : MonoBehaviour
{
    Renderer m_ObjectRenderer;

    void Start()
    {
        //Fetch the GameObject's Renderer component
        m_ObjectRenderer = GetComponent<Renderer>();
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if (gameObject.activeInHierarchy)
        //{
        //    if (!m_ObjectRenderer.isVisible)
        //    {
         //       gameObject.SetActive(false);
        //    }
            //Debug.Log("Left screen");
        //}
    }
}
