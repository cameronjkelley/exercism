using System;

class BankAccount
{
	private bool Account;
	private int Balance;
	public void Open()
	{
		Account = true;
		Balance = 0;
	}
	public int GetBalance()
	{
		if (Account) return Balance;
		else throw new InvalidOperationException();
	}
	public void UpdateBalance(int amount)
	{
		if (Account) Balance += amount;
		else throw new InvalidOperationException();
	}
	public void Close()
	{
		Account = false;
	}
}
