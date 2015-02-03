import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;


public class _02_SequenceOfEqualStrings {

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
		
		for (Map.Entry<String, Integer> entry : wordsCount.entrySet()) {
		    String key = entry.getKey();
		    Integer value = entry.getValue();

		    for (int index = 0; index < value; index++) {
				System.out.print(key + " ");
			}
		    System.out.println();
		}
	}

}
