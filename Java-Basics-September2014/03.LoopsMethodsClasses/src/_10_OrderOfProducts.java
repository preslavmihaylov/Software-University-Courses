import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;


public class _10_OrderOfProducts {

	public static void main(String[] args) throws IOException {
		List<Product> products = new ArrayList<Product>();
		List<Product> order = new ArrayList<Product>();	
		
		// getting input from text file Products
		@SuppressWarnings("resource")
		BufferedReader reader = new BufferedReader(new FileReader(
				"_10_OrderOfProductsProducts.txt"));
		
		String line = null;
		
		while ((line = reader.readLine()) != null) {
		    String[] input = line.split(" ");
		    products.add(new Product());
		    products.get(products.size() - 1).setName(input[0]);
		    products.get(products.size() - 1).setPrice(Double.parseDouble(input[1]));
		}
		
		// getting input from text file Orders
		reader = new BufferedReader(new FileReader("_10_OrderOfProductsOrder.txt"));
		
		while ((line = reader.readLine()) != null) {
		    String[] input = line.split(" ");
		    order.add(new Product());
		    order.get(order.size() - 1).setName(input[1]);
		    order.get(order.size() - 1).setPrice(Double.parseDouble(input[0]));
		}
		
		/*
		 * for each element of the different arrays,
		 * check whether their names match and if so,
		 * multiply their prices and add them
		 * to the corresponding element of the order list 
		 */
		
		for (int productsIndex = 0; productsIndex < products.size(); productsIndex++) {
			for (int orderIndex = 0; orderIndex < order.size(); orderIndex++) {
				
				if (products.get(productsIndex).getName().equals(
						order.get(orderIndex).getName())) {
					
					order.get(orderIndex).setPrice(products.get(
							productsIndex).getPrice() * order.get(orderIndex).getPrice());
				}
			}
		}
		
		// calculate the total price
		double result = 0;
		
		for (Product product : order) {
			result += product.getPrice();
		}
		
		// output the price in the text file
		PrintWriter out = new PrintWriter("_10_OrderOfProductsOutput.txt");
		
		out.println(String.format("%.1f", result));
		out.close();
	}

}
