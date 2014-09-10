import java.util.Random;
import java.util.Scanner;


public class _06_RandomHandsOf5Cards {
	
	public static void main(String[] args) {
		String[] cardFaces = {"2", "3", "4", "5", "6", "7", "8",
			"9", "10", "J", "Q", "K", "A"};
		
		String[] cardSuits = {"♣", "♦", "♥", "♠"};
		
		Random randomGenerator = new Random();
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int numOfCombinations = scan.nextInt();
		
		for (int index = 0; index < numOfCombinations; index++) {
			
			for (int cards = 0; cards < 5; cards++) {
				String output = cardFaces[randomGenerator.nextInt(cardFaces.length)] +
						cardSuits[randomGenerator.nextInt(cardSuits.length)];
				System.out.print(output + " ");
			}
			System.out.println();
		}
	}
}
