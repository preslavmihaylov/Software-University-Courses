package _02_Shop.Products;

import _02_Shop.Enumerations.AgeRestriction;

public abstract class ElectronicsProduct extends Product {
	protected int guaranteePeriod;
	
	
	public ElectronicsProduct(String name, double price, int quantity,
			AgeRestriction restriction) {
		super(name, price, quantity, restriction);
		// TODO Auto-generated constructor stub
	}

	public abstract int getGuaranteePeriod();
}
