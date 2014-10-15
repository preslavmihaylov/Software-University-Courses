import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;


public class _04_Nuts {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int inputCount = Integer.parseInt(scan.nextLine());
		TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
		
		for (int index = 0; index < inputCount; index++) {
			String[] input = scan.nextLine().split(" ");
			
			// [0] - company; [1] - nuts; [2] - amount + kg;
			removeKg(input);
			
			LinkedHashMap<String, Integer> currentMap = data.get(input[0]);
			
			if (currentMap == null) {
				currentMap = new LinkedHashMap<>();
				currentMap.put(input[1], Integer.parseInt(input[2]));
				
			} else {
				Integer amount = currentMap.get(input[1]);
				
				if (amount == null) {
					amount = Integer.parseInt(input[2]);
				} else {
					amount += Integer.parseInt(input[2]);
				}
				
				currentMap.put(input[1], amount);
			}
			
			data.put(input[0], currentMap);
		}
		
		for (String key : data.keySet()) {
			System.out.print(key + ": ");
			LinkedHashMap<String, Integer> currentMap = data.get(key);
			
			for (String nutType : currentMap.keySet()) {
				System.out.print(nutType + "-");
				int amount = currentMap.get(nutType);
				
				String lastKey = getLastKey(currentMap);
				
				if (lastKey.equals(nutType)) {
					System.out.print(amount + "kg");
				} else {
					System.out.print(amount + "kg, ");
				}
				
			}
			
			System.out.println();
		}
	}
	
	public static String getLastKey(LinkedHashMap<String, Integer> myMap) {
		  String out = null;
		  for (String key : myMap.keySet()) {
		    out = key;
		  }
		  return out;
		}

	private static void removeKg(String[] input) {
		String removeKg = "";
		for (int ch = 0; ch < input[2].length() - 2; ch++) {
			removeKg += "" + input[2].charAt(ch);
		}
		input[2] = removeKg;
	}
}
