import java.util.Scanner;
import java.util.TreeMap;


public class _04_LogsAggregator {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int inputCounts = Integer.parseInt(scan.nextLine());
		TreeMap<String, TreeMap<String, Integer>> logs = new TreeMap<>();
		
		for (int i = 0; i < inputCounts; i++) {
			String[] input = scan.nextLine().split(" ");
			
			TreeMap<String, Integer> currentMap = logs.get(input[1]);
			
			if (currentMap == null) {
				currentMap = new TreeMap<>();
				currentMap.put(input[0], Integer.parseInt(input[2]));
			} else {
				Integer currentDuration = currentMap.get(input[0]);
				if (currentDuration == null) {
					currentDuration = Integer.parseInt(input[2]);
				} else {
					currentDuration += Integer.parseInt(input[2]);
				}
				
				currentMap.put(input[0], currentDuration);
			}
			
			logs.put(input[1], currentMap);
		}
		
		for (String user : logs.keySet()) {
			System.out.print(user + ": ");
			
			TreeMap<String, Integer> currentMap = logs.get(user);
			int totalValue = 0;
			
			for (Integer value : currentMap.values()) {
				totalValue += value;
			}
			
			System.out.print(totalValue + " ");
			
			System.out.println(currentMap.keySet());
		}
	}

}
