import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		ArrayList<String> uniqueWords = new ArrayList<>();
		
		String[] input = scan.nextLine().toLowerCase().split("\\W+");
		
		for (String word : input) {
			if (!uniqueWords.contains(word)) {
				uniqueWords.add(word);
			}
		}
		
		Collections.sort(uniqueWords);
		
		for (String word : uniqueWords) {
			System.out.print(word + " ");
		}
	}

}
