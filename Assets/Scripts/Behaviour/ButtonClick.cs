using Assets.Scripts;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    [SerializeField]
    public InputActionReference buttonPressAction;

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
                Random.Range(-20.0f, 20.0f), 
                Random.Range(5.0f, 30.0f), 
                Random.Range(-20.0f, 20.0f));
            letter.transform.position = transform.position;
            letter.transform.rotation = transform.rotation;
            letter.SetActive(true);

            GameController.Instance.IncreaseSpam();
        }
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
