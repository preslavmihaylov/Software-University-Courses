import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class _04_Orders {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		Map<String, TreeMap<String, Integer>> orders = 
				new LinkedHashMap<String, TreeMap<String, Integer>>();
		
		int inputCount = Integer.parseInt(scan.nextLine());
		
		for (int count = 0; count < inputCount; count++) {
			String[] input = scan.nextLine().split(" ");
			
			boolean hasElement = orders.containsKey(input[2]);
			if (hasElement) {
				TreeMap<String, Integer> inner = orders.get(input[2]);
				
				boolean hasPerson = inner.containsKey(input[0]);
				
				if (hasPerson) {
					int addValue = Integer.parseInt(input[1]);
					int currentValue = inner.get(input[0]);
					inner.put(input[0], currentValue + addValue);
				} else {
					inner.put(input[0], Integer.parseInt(input[1]));
				}
				
				orders.put(input[2], inner);
						
			} else {
				
				TreeMap<String, Integer> inner = 
						new TreeMap<String, Integer>();
				inner.put(input[0], Integer.parseInt(input[1]));
				orders.put(input[2], inner);
			}
		}
		
		for (String key : orders.keySet()) {
			TreeMap<String, Integer> inner = orders.get(key);
			System.out.print(key + ": ");
			String output = "";
			
			for (String innerKey : inner.keySet()) {
				int value = inner.get(innerKey);
				output += innerKey + " " + value + ", ";
			}
			
			for (int ch = 0; ch < output.length() - 2; ch++) {
				System.out.print(output.charAt(ch));
			}
			System.out.println();
		}
	}
	
	

}
