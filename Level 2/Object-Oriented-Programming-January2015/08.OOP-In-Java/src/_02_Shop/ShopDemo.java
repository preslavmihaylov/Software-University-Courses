package _02_Shop;

import java.util.ArrayList;
import java.util.Date;
import java.util.Optional;

import _02_Shop.Enumerations.AgeRestriction;
import _02_Shop.Interfaces.Expirable;
import _02_Shop.Products.Appliance;
import _02_Shop.Products.Computer;
import _02_Shop.Products.FoodProduct;
import _02_Shop.Products.Product;

public class ShopDemo {

	@SuppressWarnings("deprecation")
	public static void main(String[] args) {
		FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400,
				AgeRestriction.ADULT, new Date(2015, 02, 19));
		Customer pecata = new Customer("Pecata", 17, 30.00);
		try {
			PurchaseManager.processPurchase(cigars, pecata);
		} catch (IllegalArgumentException e) {
			System.out.println(e.getMessage());
		}
		
		Customer gopeto = new Customer("Gopeto", 18, 0.44);
		
		try {
			PurchaseManager.processPurchase(cigars, gopeto);
		} catch (IllegalArgumentException e) {
			System.out.println(e.getMessage());
		}
		
		ArrayList<Product> products = new ArrayList<>();
		products.add(new FoodProduct("A product", 18, 25, 
				AgeRestriction.NONE, new Date(2015, 02, 19)));
		products.add(new FoodProduct("yet another product", 5, 12,
				AgeRestriction.ADULT, new Date(2015, 05, 10)));
		products.add(new FoodProduct("Food", 18, 20, 
				AgeRestriction.NONE, new Date(2010, 3, 11)));
		products.add(new FoodProduct("Junk food", 10, 12, 
				AgeRestriction.ADULT, new Date(2012, 04, 19)));
		
		products.add(new Computer("PC", 100, 25, 
				AgeRestriction.ADULT));
		products.add(new Appliance("Appliance", 17.70, 7,
				AgeRestriction.NONE));
		products.add(new Computer("Yet another PC", 120, 16, 
				AgeRestriction.ADULT));
		products.add(new Appliance("Junk Appliance", 57, 11, 
				AgeRestriction.NONE));

		System.out.println("Expirable product with soonest date of expiration.");
		Optional<Product> productWithSoonestExpirationDate = products.stream()
				.filter(p -> p instanceof Expirable)
				.sorted((p1, p2) -> {
					Expirable expirableProduct1 = (Expirable)p1;
					Expirable expirableProduct2 = (Expirable)p2;
					
					if (expirableProduct1.getExpirationDate().after(expirableProduct2.getExpirationDate())) {
						return 1;
					} else if (expirableProduct1.getExpirationDate().before(expirableProduct2.getExpirationDate())) {
						return -1;
					} else {
						return 0;
					}
				})
				.findFirst();
		
		System.out.println(productWithSoonestExpirationDate.get().getName());
		
		System.out.println();
		System.out.println("Products with adult age restriction sorted by price");
		
		products.stream()
				.filter(p -> p.getRestriction() == AgeRestriction.ADULT)
				.sorted((p1, p2) -> {
					if (p1.getPrice() > p2.getPrice()) {
						return 1;
					} else if (p1.getPrice() < p2.getPrice()) {
						return -1;
					} else {
						return 0;
					}
				})
				.forEach(p -> System.out.println(p.getName()));
	}

}
