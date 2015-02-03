
public class _03_FullHouse {
	
	static String[] cardFaces = {"2", "3", "4", "5", "6", "7", "8",
		"9", "10", "J", "Q", "K", "A"};
	
	static String[] cardSuits = {"♣", "♦", "♥", "♠"};

	static int count = 0;
	
	public static void main(String[] args) {
		
		// generate possible card face combinations where cardFace1 != cardFace2
		for (int cardIndex1 = 0; cardIndex1 < cardFaces.length; cardIndex1++) {
			for (int cardIndex2 = 0; cardIndex2 < cardFaces.length; cardIndex2++) {
				if (cardIndex2 != cardIndex1) {
					generateCombinations(cardIndex1, cardIndex2);
				}
			}
		}
		
		System.out.println();
		System.out.printf("%d full houses",count);
	}

	private static void generateCombinations(int index1, int index2) {
		// generate every possible card suit combination without repetitions
		for (int suit1 = 0; suit1 < cardSuits.length - 2; suit1++) {
			for (int suit2 = suit1 + 1; suit2 < cardSuits.length - 1; suit2++) {
				for (int suit3 = suit2 + 1; suit3 < cardSuits.length; suit3++) {
					for (int suit4 = 0; suit4 < cardSuits.length - 1; suit4++) {
						for (int suit5 = suit4 + 1; suit5 < cardSuits.length; suit5++) {
							String output = cardFaces[index1] + cardSuits[suit1] + " ";
							output += cardFaces[index1] + cardSuits[suit2] + " ";
							output += cardFaces[index1] + cardSuits[suit3] + " ";
							output += cardFaces[index2] + cardSuits[suit4] + " ";
							output += cardFaces[index2] + cardSuits[suit5];
							
							System.out.printf("(%s)", output);
							count++;
						}
					}
					System.out.println();
				}
			}
		}
		
	}

}
