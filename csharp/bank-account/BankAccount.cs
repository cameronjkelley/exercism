using System;

class BankAccount
{
	private bool Account = false;
	private int Balance = 0;
	private Object Lock = new object();

	public void Open()
	{
			Account = true;
	}
	public int GetBalance()
	{
		lock(Lock)
		{
			if (Account) return Balance;
			else throw new InvalidOperationException();
		}
	}
	public void UpdateBalance(int amount)
	{
		lock(Lock)
		{
			if (Account) Balance += amount;
			else throw new InvalidOperationException();
		}
	}
	public void Close()
	{
			Account = false;
	}
}
