using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public BotSO botSO;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendLetter(botSO.time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendLetter(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            Debug.Log("Send letter with bot");
            yield return new WaitForSeconds(time);
        }
    }
}
