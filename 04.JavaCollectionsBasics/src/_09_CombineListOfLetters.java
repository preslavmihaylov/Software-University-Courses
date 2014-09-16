import java.util.ArrayList;
import java.util.Scanner;


public class _09_CombineListOfLetters {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		ArrayList<String> letterGroup = new ArrayList<>();
		ArrayList<String> firstGroup = new ArrayList<>();
		
		String[] input1 = scan.nextLine().split(" ");
		
		
		for (String letter : input1) {
			letterGroup.add(letter);
			firstGroup.add(letter);
		}
		
		String[] input2 = scan.nextLine().split(" ");
		
		for (String letter : input2) {
			if (!firstGroup.contains(letter)) {
				letterGroup.add(letter);
			}
		}
		
		for (String letter : letterGroup) {
			System.out.print(letter + " ");
		}
	}

}
