package _02_Shop.Products;

import _02_Shop.Enumerations.AgeRestriction;

public class Appliance extends ElectronicsProduct {
	private static final int GUARANTEE_PERIOD = 6;
	
	public Appliance(String name, double price, int quantity,
			AgeRestriction restriction) {
		super(name, price, quantity, restriction);
		// TODO Auto-generated constructor stub
	}

	@Override
	public int getGuaranteePeriod() {
		return Appliance.GUARANTEE_PERIOD;
	}

	@Override
	public double getPrice() {
		if (this.getQuantity() < 50) {
			return (105 * this.price) / 100;
		} else {
			return this.price;
		}
	}
}
