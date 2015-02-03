import java.util.Scanner;


public class _02_GenerateThreeLetterWords {
	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String input = scan.next();
		
		for (int letter1 = 0; letter1 < input.length(); letter1++) {
			for (int letter2 = 0; letter2 < input.length(); letter2++) {
				for (int letter3 = 0; letter3 < input.length(); letter3++) {
					char ch1 = input.charAt(letter1);
					char ch2 = input.charAt(letter2);
					char ch3 = input.charAt(letter3);
					
					System.out.print("" + ch1 + ch2 + ch3 + " ");
				}
			}
		}
	}
}
