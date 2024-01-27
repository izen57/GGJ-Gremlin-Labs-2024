using UnityEngine;

using Object = UnityEngine.Object;

public class GameController
{
	public float Money { get; private set; }
	public int SpamSent { get; private set; }

	public int SpamRead { get; private set; }
	private int _internalSpamReadCounter;

	public float ReadFrequency { get; private set; }
	public float MoneyPerRead { get; private set; }

	private static GameController _instance = null;
	public static GameController Instance
	{
		get {
			_instance ??= new GameController();
			return _instance;
		}
	}

	private GameController()
	{
		Debug.Log("The spammer has been initialized.");

		SpamSent = 0;
		SpamRead = 0;
		_internalSpamReadCounter = 0;
		Money = 0f;
		MoneyPerRead = 0.2f;
		ReadFrequency = 10f;
	}

	public void IncreaseSpam()
	{
		SpamSent++;
		Object.FindObjectOfType<SpamSentText>().ChangeText(SpamSent.ToString());
		Debug.Log("SpamSent has been increased.");
	}

	public void IncreaseSpam(int spamCount)
	{
		SpamSent += spamCount;
		Object.FindObjectOfType<SpamSentText>().ChangeText(SpamSent.ToString());
		Debug.Log($"SpamSent has been increased by {spamCount}.");
	}

	public void IncreaseMoney()
	{
		Money += MoneyPerRead;
		Object.FindObjectOfType<MoneyText>().ChangeText(Money.ToString());
		Debug.Log("Money has been increased.");
	}

	public bool OnSpamRead()
	{
		if (++_internalSpamReadCounter % ReadFrequency == 0) {
			IncreaseMoney();
			SpamRead++;
			Object.FindObjectOfType<SpamReadText>().ChangeText(SpamRead.ToString());
			Debug.Log("SpamRead has been increased.");

			return true;
		}

		return false;
	}

	public bool SendSpam(int spamCount)
	{
		IncreaseSpam(spamCount);
		return OnSpamRead();
	}
}
