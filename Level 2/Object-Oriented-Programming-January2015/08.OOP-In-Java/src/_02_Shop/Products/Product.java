package _02_Shop.Products;

import _02_Shop.Enumerations.AgeRestriction;
import _02_Shop.Interfaces.Buyable;

public abstract class Product implements Buyable {
	private String name;
	protected double price;
	private int quantity;
	private AgeRestriction restriction;
	
	public Product(String name, double price, int quantity, AgeRestriction restriction) {
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quantity);
		this.setRestriction(restriction);
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
	public double getPrice() {
		return price;
	}
	public void setPrice(double price) {
		if (price < 0) {
			throw new IllegalArgumentException();
		}
		this.price = price;
	}
	public int getQuantity() {
		return quantity;
	}
	public void setQuantity(int quantity) {
		if (quantity < 0) {
			throw new IllegalArgumentException();
		}
		this.quantity = quantity;
	}
	public AgeRestriction getRestriction() {
		return restriction;
	}
	public void setRestriction(AgeRestriction restriction) {
		if (restriction == null) {
			throw new NullPointerException();
		}
		this.restriction = restriction;
	}
	
}
