import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class _04_StraightFlush {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("[^0-9JQKASHDC]+");
		
		ArrayList<String> spades = new ArrayList<>();
		ArrayList<String> hearts = new ArrayList<>();
		ArrayList<String> diamonds = new ArrayList<>();
		ArrayList<String> clubs = new ArrayList<>();
		boolean resultFound = false;
		
		for (int i = 0; i < input.length; i++) {
			String card = "";
			String suit = "";
			if (input[i].length() > 2) {
				card = "10";
				suit = "" + input[i].charAt(2);
			} else {
				switch (input[i].charAt(0)) {
				case 'J':
					card = "11";
					break;
				case 'Q':
					card = "12";
					break;
				case 'K':
					card = "13";
					break;
				case 'A':
					card = "14";
					break;

				default:
					card = "" + "0" +input[i].charAt(0);
					break;
				}
				
				suit = "" + input[i].charAt(1);
			}
			
			switch (suit) {
			case "S":
				spades.add(card + suit);
				break;
			case "H":
				hearts.add(card + suit);
				break;
			case "D":
				diamonds.add(card + suit);
				break;
			case "C":
				clubs.add(card + suit);
				break;
			}
		}
		
		Collections.sort(spades);
		Collections.sort(hearts);
		Collections.sort(diamonds);
		Collections.sort(clubs);
		
		for (int i = 0; i < spades.size() - 4; i++) {
			int card1 = getCard(spades, i);
			int card2 = getCard(spades, i + 1);
			int card3 = getCard(spades, i + 2);
			int card4 = getCard(spades, i + 3);
			int card5 = getCard(spades, i + 4);
			
			boolean straight = card2 == card1 + 1 &&
							   card3 == card2 + 1 &&
							   card4 == card3 + 1 &&
							   card5 == card4 + 1; 
			
			if (straight) {
				resultFound = true;
				outputStraight(card1, card2, card3, card4, card5, spades.get(i).charAt(2));
			}
		}
		
		for (int i = 0; i < hearts.size() - 4; i++) {
			int card1 = getCard(hearts, i);
			int card2 = getCard(hearts, i + 1);
			int card3 = getCard(hearts, i + 2);
			int card4 = getCard(hearts, i + 3);
			int card5 = getCard(hearts, i + 4);
			
			boolean straight = card2 == card1 + 1 &&
							   card3 == card2 + 1 &&
							   card4 == card3 + 1 &&
							   card5 == card4 + 1; 
			
			if (straight) {
				resultFound = true;
				outputStraight(card1, card2, card3, card4, card5, hearts.get(i).charAt(2));
			}
		}
		
		for (int i = 0; i < diamonds.size() - 4; i++) {
			int card1 = getCard(diamonds, i);
			int card2 = getCard(diamonds, i + 1);
			int card3 = getCard(diamonds, i + 2);
			int card4 = getCard(diamonds, i + 3);
			int card5 = getCard(diamonds, i + 4);
			
			boolean straight = card2 == card1 + 1 &&
							   card3 == card2 + 1 &&
							   card4 == card3 + 1 &&
							   card5 == card4 + 1; 
			
			if (straight) {
				resultFound = true;
				outputStraight(card1, card2, card3, card4, card5, diamonds.get(i).charAt(2));
			}
		}
		
		for (int i = 0; i < clubs.size() - 4; i++) {
			int card1 = getCard(clubs, i);
			int card2 = getCard(clubs, i + 1);
			int card3 = getCard(clubs, i + 2);
			int card4 = getCard(clubs, i + 3);
			int card5 = getCard(clubs, i + 4);
			
			boolean straight = card2 == card1 + 1 &&
							   card3 == card2 + 1 &&
							   card4 == card3 + 1 &&
							   card5 == card4 + 1; 
			
			if (straight) {
				resultFound = true;
				outputStraight(card1, card2, card3, card4, card5, clubs.get(i).charAt(2));
			}
		}
		
		if (!resultFound) {
			System.out.println("No Straight Flushes");
		}
		
	}

	private static void outputStraight(int card1, int card2, int card3,
			int card4, int card5, char suitType) {
		String suit = "";
		switch (suitType) {
		case 'S':
			suit = "S";
			break;
		case 'H':
			suit = "H";
			break;
		case 'D':
			suit = "D";
			break;
		case 'C':
			suit = "C";
			break;
		}
		
		String output1 = getCardValue(card1) + suit;
		String output2 = getCardValue(card2) + suit;
		String output3 = getCardValue(card3) + suit;
		String output4 = getCardValue(card4) + suit;
		String output5 = getCardValue(card5) + suit;
		
		System.out.printf("[%s, %s, %s, %s, %s]", output1, output2, output3, output4, output5);
		System.out.println();
	}

	private static String getCardValue(int card) {
		String returnValue = "";
		switch (card) {
		case 11:
			returnValue = "J";
			break;
		case 12:
			returnValue = "Q";
			break;
		case 13:
			returnValue = "K";
			break;
		case 14:
			returnValue = "A";
			break;
		default:
			returnValue = "" + card;
			break;
		}
		return returnValue;
	}

	private static int getCard(ArrayList<String> cards, int i) {
		int card = Integer.parseInt("" + cards.get(i).charAt(0) + cards.get(i).charAt(1));
		return card;
	}

}
