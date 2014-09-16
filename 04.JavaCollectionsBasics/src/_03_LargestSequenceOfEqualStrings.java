import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;


public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] words = scan.nextLine().split(" ");
		
		HashMap<String, Integer> wordsCount = new HashMap<>();
		
		for (String word : words) {
			  Integer count = wordsCount.get(word);
			  if (count == null) {
			    count = 0; 
			  }
			  wordsCount.put(word, count+1);
		}
		
		String largestString = "";
		Integer largestSequence = 0;
		
		for (Map.Entry<String, Integer> entry : wordsCount.entrySet()) {
		    String key = entry.getKey();
		    Integer value = entry.getValue();

		    if (value > largestSequence) {
				largestString = key;
				largestSequence = value;
			}
		}
		
		for (int index = 0; index < largestSequence; index++) {
			System.out.print(largestString + " ");
		}
		
	}

}
