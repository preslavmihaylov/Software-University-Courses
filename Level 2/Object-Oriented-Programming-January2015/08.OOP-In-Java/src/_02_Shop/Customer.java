package _02_Shop;

public class Customer {
	private String name;
	private int age;
	private double balance;
	
	public Customer(String name, int age, double balance) {
		this.setName(name);
		this.setAge(age);
		this.setBalance(balance);
	}
	
	public String getName() {
		return name;
	}
	
	private void setName(String name) {
		if (name.equals(null) || name.equals("")) {
			throw new IllegalArgumentException();
		}
		this.name = name;
	}
	
	public int getAge() {
		return age;
	}
	
	private void setAge(int age) {
		if (age < 0) {
			throw new IllegalArgumentException();
		}
		this.age = age;
	}
	
	public double getBalance() {
		return balance;
	}
	
	public void setBalance(double balance) {
		if (balance < 0) {
			throw new IllegalArgumentException("The balance cannot be negative");
		}
		this.balance = balance;
	}
}
