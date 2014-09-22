import java.util.Iterator;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class ActivityTracker {

	public static void main(String[] args) {
		
		//read the input for the number of data lines
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		
		//create the construct to hold the data
		TreeMap<Integer, TreeMap<String, Integer>> months = new TreeMap<>();

		//populate the data in the construct
		for (int i = 0; i < n; i++) {
			String[] input = str.nextLine().split(" ");
			String[] date = input[0].split("/");
			
			//create temporary variables for the current data line
			int month = Integer.parseInt(date[1]);
			String user = input[1];
			int distance = Integer.parseInt(input[2]);
			
			//check if the month is already present or not and act accordingly
			if (!months.containsKey(month)) {
				TreeMap<String, Integer> users = new TreeMap<>();
				users.put(user, distance);
				months.put(month, users);
			}
			else {
				//check if the user is already present or not and act accordingly
				TreeMap<String, Integer> users = months.get(month);
				if (!users.containsKey(user)) {
					users.put(user, distance);
				}
				else {
					int tempDistance = users.get(user);
					tempDistance += distance;
					users.put(user, tempDistance);
				}
				months.put(month, users);
			}
		}
		
		//print the output as needed
		for (Iterator it = months.entrySet().iterator(); it.hasNext();) {
			Map.Entry month = (Map.Entry) it.next();
			
			String outputLine = month.getKey() + ": ";

			TreeMap users = (TreeMap) month.getValue();
			for (Iterator it2 = users.entrySet().iterator(); it2.hasNext();) {
				Map.Entry user = (Map.Entry) it2.next();
				
				outputLine += user.getKey() + "(" + user.getValue() + "), ";
			}

			outputLine = outputLine.substring(0, outputLine.length() - 2);
			System.out.println(outputLine);
		}
		
	}
}
