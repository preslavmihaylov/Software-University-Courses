import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;


public class _04_ActivityTracker {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int inputCount = Integer.parseInt(scan.nextLine());
		
		TreeMap<Integer, TreeMap<String, Integer>> data = new TreeMap<>();
		
		for (int i = 0; i < inputCount; i++) {
			String[] input = scan.nextLine().split("[/ ]+");
			
			// [0] - day; [1] - month; [2] - year; [3] - name; [4] - distance
			
			TreeMap<String, Integer> currentUser = data.get(Integer.parseInt(input[1]));
			
			if (currentUser == null) {
				currentUser = new TreeMap<>();
				currentUser.put(input[3], Integer.parseInt(input[4]));
				
			} else {
				Integer distance = currentUser.get(input[3]);
				
				if (distance == null) {
					distance = Integer.parseInt(input[4]);
				} else {
					distance += Integer.parseInt(input[4]);
				}
				
				currentUser.put(input[3], distance);
			}
			
			data.put(Integer.parseInt(input[1]), currentUser);
		}
		
		for (Integer month : data.keySet()) {
			System.out.print("" + month + ": ");
			
			TreeMap<String, Integer> currentUser = data.get(month);
			
			for (String user : currentUser.keySet()) {
				System.out.print(user + "(");
				int distance = currentUser.get(user);
				
				System.out.print(distance + ")");
				
				Entry<String, Integer> lastElementCheck = currentUser.lastEntry();
				if (!lastElementCheck.getKey().equals(user)) {
					System.out.print(", ");
				}
			}
			
			System.out.println();
		}
	}

}
