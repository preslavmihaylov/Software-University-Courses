
public class _04_FullHouseWithJokers {
	
	static String[] cardFaces = {"2", "3", "4", "5", "6", "7", "8",
		"9", "10", "J", "Q", "K", "A"};
	
	static String[] cardSuits = {"♣", "♦", "♥", "♠"};

	static String[] loops = new String[5];
	static int count = 0;
	
	public static void main(String[] args) {
		
		for (int jokersCount1 = 0; jokersCount1 <= 3; jokersCount1++) {
			for (int jokersCount2 = 0; jokersCount2 <= 2; jokersCount2++) {
				for (int cardIndex1 = 0; cardIndex1 < cardFaces.length; cardIndex1++) {
					for (int cardIndex2 = 0; cardIndex2 < cardFaces.length; cardIndex2++) {
						if (jokersCount1 == 3) {
							cardIndex1 = cardFaces.length - 1;
						}
						
						if (jokersCount2 == 2) {
							cardIndex2 = cardFaces.length - 1;
						}
						
						if (cardIndex2 != cardIndex1) {
							
							for (int index = 0; index < jokersCount1; index++) {
								loops[index] = "*";
							}
							
							System.out.println();
							generateFirstSet(cardIndex1, cardIndex2, jokersCount2,
									3 - jokersCount1, 0, 0 + jokersCount1);
						}
						else if (jokersCount1 == 3 && jokersCount2 == 2) {
							System.out.print("( * * * * * )");
							count++;
						}
					}
				}
			}
		}
		
		System.out.println();
		System.out.printf("%d full houses",count);
	}

	private static void generateFirstSet(int index1, int index2, int jokersCount2,
			int cardSuitsCount, int currentSuit, int currentLoop) {
		
		if (cardSuitsCount == 0) {
			
			for (int index = 3; index < 3 + jokersCount2; index++) {
				loops[index] = "* ";
			}
			generateSecondSet(index2, 2 - jokersCount2, 0, 3 + jokersCount2);
			return;
		}
		
		for (int cardSuit = currentSuit; cardSuit < cardSuits.length; cardSuit++) {
			loops[currentLoop] = cardFaces[index1] + cardSuits[cardSuit];
			generateFirstSet(index1, index2, jokersCount2,
					cardSuitsCount - 1, currentSuit + 1, currentLoop + 1);
		}
	}
	
	private static void generateSecondSet(int index2, int cardSuitsCount,
			int currentSuit, int currentLoop) {
		
		if (cardSuitsCount == 0) {
			printResult();
			count++;
			return;
		}
		
		for (int cardSuit = currentSuit; cardSuit < cardSuits.length; cardSuit++) {
			loops[currentLoop] = cardFaces[index2] + cardSuits[cardSuit];
			generateSecondSet(index2, cardSuitsCount - 1, currentSuit + 1, currentLoop + 1);
		}
	}

	private static void printResult() {
		System.out.print("( ");
		for (int index = 0; index < loops.length; index++) {
			System.out.print(loops[index] + " ");
		}
		System.out.print(")");
	}

}
