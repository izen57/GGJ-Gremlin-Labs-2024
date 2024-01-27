using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

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
            GameController.Instance.IncreaseSpam(botSO.letters);
            GameController.Instance.OnSpamRead();
            Debug.Log("Send letter with bot");
            yield return new WaitForSeconds(time);
        }
    }
}
