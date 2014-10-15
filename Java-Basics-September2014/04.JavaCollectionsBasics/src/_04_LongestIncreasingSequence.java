import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;


public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] words = scan.nextLine().split(" ");
		
		// using LinkedHashMap so that I keep the order of the input elements
		LinkedHashMap<ArrayList<String>, Integer> sequences = new LinkedHashMap<>();
		
		ArrayList<String> currentSequence = new ArrayList<>();
		
		int lastNum = Integer.MIN_VALUE;
		int count = 0;
		
		for (String word : words) {
			
			int currentNum = Integer.parseInt(word);
			if (currentNum > lastNum) {
				/* in case the current number is bigger than the last number,
				input it in the current sequence */
				currentSequence.add(word);
				count++;
			}
			else {
				/* If the list used for iterations is directly input in the hashMap,
				it directly depends on it and if changes occur to currentSequence,
				the changes affect every list in the HashMap */
				
				ArrayList<String> newList = new ArrayList<>();
				for (String string : currentSequence) {
					newList.add(string);
				}
				
				/* in case there are lists with the same elements,
				input meaningless elements to avoid the HashMap replacing functionality */
				Integer check = sequences.get(newList);
				while (check != null) {
					newList.add("");
					check = sequences.get(newList);
				}
				
				// finally input the list to the HashMap with value - the count of its elements
				sequences.put(newList, count);
				
				/* prepare the currentSequence list to store
				the next numbers from the next sequence*/
				count = 1;
				currentSequence.clear();
				currentSequence.add(word);
			}
		
			lastNum = currentNum;
		}
		
		// input the final sequence which doesnt get iterated by the previous loop
		Integer check = sequences.get(currentSequence);
		while (check != null) {
			currentSequence.add("");
			check = sequences.get(currentSequence);
		}
		sequences.put(currentSequence, count);
		
		/* find the largest sequence by comparing
		each sequence's value (the count of its elements) */		
		ArrayList<String> longestSequence = new ArrayList<>();
		Integer largestValue = 0;
		
		for (Map.Entry<ArrayList<String>, Integer> entry : sequences.entrySet()) {
		    ArrayList<String> key = entry.getKey();
		    Integer value = entry.getValue();

		    if (value > largestValue) {
				longestSequence = key;
				largestValue = value;
			}
		    
		    // print each of the sequences on a new line
		    for (String number : key) {
				System.out.print(number + " ");
			}
		    System.out.println();
		}
		
		// finally, print the longest sequence
		System.out.print("Longest Sequence: ");
		for (int index = 0; index < longestSequence.size(); index++) {
			System.out.print(longestSequence.get(index) + " ");
		}
	}

}
