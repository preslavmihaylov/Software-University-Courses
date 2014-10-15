import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;


public class _04_CouplesFrequencies {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split(" ");
		ArrayList<String> couples = new ArrayList<String>();
		
		for (int index = 0; index < input.length - 1; index++) {
			String currentCouple = input[index] + " " + input[index + 1];
			couples.add(currentCouple);
		}
		
		Map<String, Integer> couplesCount = new LinkedHashMap<String, Integer>();
		
		for (String couple : couples) {
			  Integer count = couplesCount.get(couple);
			  if (count == null) {
			    count = 0; 
			  }
			  couplesCount.put(couple, count+1);
		}
		
		for (String key : couplesCount.keySet()) {
			double percentage = (double)couplesCount.get(key) / couples.size();
			percentage *= 100;
			
		    System.out.print("" + key + " -> ");
		    System.out.printf("%.2f", percentage);
		    System.out.println("%");
		}
	}

}
