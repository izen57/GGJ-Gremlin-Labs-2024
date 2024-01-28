using Assets.Scripts;

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    [SerializeField]
    public InputActionReference buttonPressAction;
    public GameObject successAnimation;

    private List<GameObject> pooledObjects;
    private List<Rigidbody> rbs;
    public GameObject objectToPool;
    public int amountToPool;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        rbs = new List<Rigidbody>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
            rbs.Add(tmp.GetComponent<Rigidbody>());
        }
        successAnimation = Instantiate(successAnimation);
        successAnimation.SetActive(false);
    }

    private void OnEnable()
    {
        buttonPressAction.action.performed += PressHandler;
        buttonPressAction.action.Enable();
    }

    private void OnDisable()
    {
        buttonPressAction.action.performed -= PressHandler;
        buttonPressAction.action.Disable();
    }

    private void PressHandler(InputAction.CallbackContext context)
    {
        int letterIndex = GetFreeObjectIndex();
        if (letterIndex > -1)
        {
            GameObject letter = pooledObjects[letterIndex];
            Rigidbody rb = rbs[letterIndex];
            rb.velocity = new Vector3(
                Random.Range(-15.0f, 15.0f), 
                Random.Range(3.0f, 15.0f), 
                Random.Range(-15.0f, 15.0f));
            letter.transform.SetPositionAndRotation(transform.position, transform.rotation);
            letter.SetActive(true);

            bool status = GameController.Instance.SendSpam(1);
            if (status)
            {
                Debug.Log("Success");
                float time = 2;
                StartCoroutine(PlaySuccessAnimation(time, letter));
            }
        }
    }

    IEnumerator PlaySuccessAnimation(float time, GameObject letter)
    {
        
        yield return new WaitForSeconds(time);
        letter.SetActive(false);
        successAnimation.transform.position = letter.transform.position;
        successAnimation.SetActive(true);
        yield return new WaitForSeconds(3);
        successAnimation.SetActive(false);
    }

public int GetFreeObjectIndex()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return i;
            }
        }
        return -1;
    }


}
