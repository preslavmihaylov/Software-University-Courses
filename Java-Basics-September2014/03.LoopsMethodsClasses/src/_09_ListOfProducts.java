import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;


public class _09_ListOfProducts {
	
	public static void main(String[] args) throws IOException {
		
		List<Product> products = new ArrayList<Product>();
		
		// getting input from text file
		@SuppressWarnings("resource")
		BufferedReader reader = new BufferedReader(new FileReader(
				"_09_ListOfProductsInput.txt"));
		
		String line = null;
		
		while ((line = reader.readLine()) != null) {
		    String[] input = line.split(" ");
		    products.add(new Product());
		    products.get(products.size() - 1).setName(input[0]);
		    products.get(products.size() - 1).setPrice(Double.parseDouble(input[1]));
		}
		
		// sorting list by its price property ascending
		Collections.sort(products, new Comparator<Product>() {
			  public int compare(Product c1, Product c2) {
			    if (c1.getPrice() > c2.getPrice()) return 1;
			    if (c1.getPrice() < c2.getPrice()) return -1;
			    return 0;
			  }});
		
		
		String[] output = new String[products.size()];
		
		// getting products in the elements of the output array
		for (int index = 0; index < output.length; index++) {
			output[index] = String.format("%.2f", products.get(index).getPrice()) + " "
					+ products.get(index).getName();
		}
		
		// output the string in the text file
		PrintWriter out = new PrintWriter("_09_ListOfProductsOutput.txt");
		
		for (String product : output) {
			out.println(product);
		}
		out.close();
	}
}

