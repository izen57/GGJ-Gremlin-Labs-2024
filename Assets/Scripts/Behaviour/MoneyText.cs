using TMPro;

using UnityEngine;

public class MoneyText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_Object;

	// Start is called before the first frame update
	void Start()
	{
		//m_Object = GetComponent<TextMeshProUGUI>();
		m_Object.text = "$0";
	}

	public void ChangeText(string text)
	{
		m_Object.text = text;
		Debug.Log("MoneyText has been changed.");
	}
}
