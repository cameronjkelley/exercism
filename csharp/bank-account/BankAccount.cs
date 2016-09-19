using System;

class BankAccount
{
	private enum Status { Open, Closed };
	private Status Account;
	private int Balance;
	public void Open()
	{
		Account = Status.Open;
		Balance = 0;
	}
	public int GetBalance()
	{
		if (Account == Status.Open) return Balance;
		else throw new InvalidOperationException();
	}
	public void UpdateBalance(int amount)
	{
		if (Account == Status.Open) Balance += amount;
		else throw new InvalidOperationException();
	}
	public void Close()
	{
		Account = Status.Closed;
	}
}
