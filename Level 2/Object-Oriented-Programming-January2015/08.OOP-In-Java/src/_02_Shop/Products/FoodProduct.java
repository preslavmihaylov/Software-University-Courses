package _02_Shop.Products;

import java.util.Date;

import _02_Shop.Enumerations.AgeRestriction;
import _02_Shop.Interfaces.Expirable;

public class FoodProduct extends Product implements Expirable {
	private Date expirationDate;
	
	public FoodProduct(String name, double price, int quantity,
			AgeRestriction restriction, Date expirationDate) {
		super(name, price, quantity, restriction);
		
		this.setExpirationDate(expirationDate);
	}

	@Override
	public Date getExpirationDate() {
		return expirationDate;
	}


	private void setExpirationDate(Date expirationDate) {
		if (expirationDate == null) {
			throw new NullPointerException();
		}
		this.expirationDate = expirationDate;
	}
	
	@Override
	public double getPrice() {
		// checking whether the date of expiration is upcoming in 15 days
		if (this.getExpirationDate().getTime() - new Date().getTime() < 86400 * 1000 * 15) {
			return (70 * this.price) / 100;
		} else {
			return this.price;
		}
	}

}
