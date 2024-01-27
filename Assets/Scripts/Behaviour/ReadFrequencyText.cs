using System;

using TMPro;

using UnityEngine;

public class ReadFrequencyText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_Object;

	// Start is called before the first frame update
	void Start()
	{
		m_Object.text = Math.Round(GameController.Instance.ReadFrequency, 2).ToString();
	}

	public void ChangeText(string text)
	{
		m_Object.text = text;
		Debug.Log("ReadFrequencyText has been changed.");
	}
}
