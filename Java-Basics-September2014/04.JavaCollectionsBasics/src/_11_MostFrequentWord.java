import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class _11_MostFrequentWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().toLowerCase().split("\\W+");
		
		TreeMap<String, Integer> wordsCount = new TreeMap<>();
		
		for (String word : input) {
			  Integer count = wordsCount.get(word);
			  if (count == null) {
			    count = 0; 
			  }
			  wordsCount.put(word, count+1);
		}
		
		int largestCount = 0;
		
		for (Object value : wordsCount.values()) {
			if (largestCount < (Integer)value) {
				largestCount = (Integer)value;
			}
		}
		
		for (Map.Entry<String, Integer> entry : wordsCount.entrySet()) {
			
			if (entry.getValue() == largestCount) {
				System.out.println(entry.getKey() + " -> " + entry.getValue());
			}
		}
	}

}
