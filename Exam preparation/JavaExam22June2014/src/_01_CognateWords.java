import java.util.ArrayList;
import java.util.Scanner;


public class _01_CognateWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("[^a-zA-Z]+");
		ArrayList<String> cognateWords = new ArrayList<>();
		boolean resultFound = false;
		
		for (int firstWord = 0; firstWord < input.length; firstWord++) {
			for (int secondWord = 0; secondWord < input.length; secondWord++) {
				for (int thirdWord = 0; thirdWord < input.length; thirdWord++) {
					String cognateWord = "" + input[firstWord] + input[secondWord];
					
					if (cognateWord.equals(input[thirdWord]) 
							&& !cognateWords.contains(cognateWord) 
							&& firstWord != secondWord && secondWord != thirdWord 
							&& firstWord != thirdWord) {
						resultFound = true;
						cognateWords.add(cognateWord);
						System.out.println(input[firstWord] + "|"
								+ input[secondWord] + "=" + input[thirdWord]);
					}
				}
			}
		}
		
		if (!resultFound) {
			System.out.println("No");
		}
	}

}
