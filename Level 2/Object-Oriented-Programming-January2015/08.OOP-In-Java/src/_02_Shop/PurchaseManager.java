package _02_Shop;

import java.util.Date;

import _02_Shop.Enumerations.AgeRestriction;
import _02_Shop.Products.FoodProduct;
import _02_Shop.Products.Product;

public final class PurchaseManager {
	
	public static void processPurchase(Product product, Customer customer) {
		if (customer.getBalance() - product.getPrice() < 0) {
			
			throw new IllegalArgumentException("The customer doesn't have enough money on his balance.");
		} else if (product.getQuantity() < 1) {
			
			throw new IllegalArgumentException("The product is out of stock.");
		} else if ((product.getRestriction() == AgeRestriction.ADULT && customer.getAge() < 18) ||
				product.getRestriction() == AgeRestriction.TEENAGER && customer.getAge() < 14) {
			
			throw new IllegalArgumentException("The customer doesn't have permissions to buy that product.");
		} else if (product instanceof FoodProduct) {
			
			if (((FoodProduct)product).getExpirationDate().before(new Date())) {
				throw new IllegalArgumentException("The product has expired.");
			}
		}
		
		product.setQuantity(product.getQuantity() - 1);
		customer.setBalance(customer.getBalance() - product.getPrice());
		
	}
}
