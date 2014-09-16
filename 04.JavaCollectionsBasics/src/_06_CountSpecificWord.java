import java.util.Scanner;


public class _06_CountSpecificWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().toLowerCase().split("[\\W]+");
		String wordToCount = scan.next();
		int count = 0;
		
		for (String word : input) {
			if (word.equals(wordToCount)) {
				count++;
			}
		}
		System.out.println(count);
	}

}
