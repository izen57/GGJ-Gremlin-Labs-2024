using UnityEngine;

using Object = UnityEngine.Object;

public class GameController
{
	public int Money { get; private set; }
	public int SpamSent { get; private set; }
	public int MoneyPerRead { get; private set; }

	//public int SpamRead { get; private set; }
	private int _internalSpamReadCounter;

	public int ReadFrequency { get; private set; }

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
		//SpamRead = 0;
		_internalSpamReadCounter = 0;
		Money = 0;
		MoneyPerRead = 2;
		ReadFrequency = 10;
	}

	public void IncreaseSpam()
	{
		SpamSent++;
		Object.FindObjectOfType<SpamSentText>(true).ChangeText(SpamSent.ToString());
		Debug.Log("SpamSent has been increased.");
	}

	private void IncreaseSpam(int spamCount)
	{
		SpamSent += spamCount;
		Object.FindObjectOfType<SpamSentText>(true).ChangeText(SpamSent.ToString());
		Debug.Log($"SpamSent has been increased by {spamCount}.");
	}

	public void IncreaseMoney()
	{
		Money += MoneyPerRead;
		Object.FindObjectOfType<MoneyText>(true).ChangeText(Money.ToString());
		Debug.Log("Money has been increased.");
	}

	public void IncreaseMoneyPerRead(int amount)
	{
		MoneyPerRead += amount;
		Object.FindObjectOfType<MoneyPerReadText>(true).ChangeText(MoneyPerRead.ToString());
		Debug.Log($"MoneyPerRead has been increased by {MoneyPerRead}.");
	}

	public void DecreaseMoneyDueToBuying(int amount)
	{
		Money -= amount;
		Object.FindObjectOfType<MoneyText>(true).ChangeText(Money.ToString());
		Debug.Log($"Money has been decreased by {amount}.");
	}

	public void IncreaseReadFrequency(int diff)
	{
		ReadFrequency += diff;
		//Object.FindObjectOfType<ReadFrequencyText>(true).ChangeText(ReadFrequency.ToString());
		Debug.Log($"ReadFrequency has been changed by {diff}.");
	}

	private bool OnSpamRead(int spamCount)
	{
		_internalSpamReadCounter += spamCount;
		if (_internalSpamReadCounter % ReadFrequency == 0) {
			IncreaseMoney();
			//SpamRead += spamCount;
			//Object.FindObjectOfType<SpamReadText>(true).ChangeText(SpamRead.ToString());
			//Debug.Log($"SpamRead has been increased by {spamCount}.");

			return true;
		}

		return false;
	}

	public bool SendSpam(int spamCount)
	{
		IncreaseSpam(spamCount);
		return OnSpamRead(spamCount);
	}
}
