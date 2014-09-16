import java.util.Scanner;


public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().toLowerCase().split("[\\W]+");
		String substringToCount = scan.next();
		int count = 0;
		
		for (int wordIndex = 0; wordIndex < input.length; wordIndex++) {
			
			int substringIndex = input[wordIndex].indexOf(substringToCount);
			
			while (substringIndex != -1) {
				String currentWord = "";
				
				for (int index = 0; index < input[wordIndex].length(); index++) {
					if (index == substringIndex) {
						currentWord += "";
					}
					else {
						currentWord += input[wordIndex].charAt(index);
					}
				}
				
				input[wordIndex] = currentWord;
				substringIndex = input[wordIndex].indexOf(substringToCount);
				count++;
			}
		}
		
		System.out.println(count);
	}

}
