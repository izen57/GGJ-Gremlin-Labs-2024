using TMPro;

using UnityEngine;

public class ReadFrequencyText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_Object;

	// Start is called before the first frame update
	void Start()
	{
		m_Object.text = GameController.Instance.ReadFrequency.ToString();
	}

	public void ChangeText(string text)
	{
		m_Object.text = text;
		Debug.Log("ReadFrequencyText has been changed.");
	}
}
