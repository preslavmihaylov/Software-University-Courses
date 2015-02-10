package _02_Shop.Products;

import _02_Shop.Enumerations.AgeRestriction;

public class Computer extends ElectronicsProduct {
	private static final int GUARANTEE_PERIOD = 24;
	
	public Computer(String name, double price, int quantity,
			AgeRestriction restriction) {
		super(name, price, quantity, restriction);
		// TODO Auto-generated constructor stub
	}

	@Override
	public int getGuaranteePeriod() {
		return Computer.GUARANTEE_PERIOD;
	}

	@Override
	public double getPrice() {
		if (this.getQuantity() > 1000) {
			return (95 * this.price) / 100;
		} else {
			return this.price;
		}
	}
}
