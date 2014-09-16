import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;


public class _12_CardsFrequencies {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("\\W+");
		
		LinkedHashMap<String, Integer> cards = new LinkedHashMap<>();
		int totalCount = 0;
		
		for (String word : input) {
			  Integer count = cards.get(word);
			  if (count == null) {
			    count = 0; 
			  }
			  cards.put(word, count+1);
			  totalCount++;
		}
		
		for (Map.Entry<String, Integer> entry : cards.entrySet()) {
			double currentPercentage = ((double)entry.getValue() / (double)totalCount) * 100;
			
			System.out.print(entry.getKey() + " -> ");
			System.out.printf("%.2f", currentPercentage);
			System.out.println(" %");
		}
	}

}
