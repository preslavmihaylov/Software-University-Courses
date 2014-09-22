import java.util.Scanner;


public class _01_StuckNumbers {

	static int[] numbers;
	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		boolean resultFound = false;
		int numCount = scan.nextInt();
		numbers = new int[numCount];
		
		for (int count = 0; count < numCount; count++) {
			numbers[count] = scan.nextInt();
		}
		
		for (int firstNum = 0; firstNum < numbers.length; firstNum++) {
			for (int secondNum = 0; secondNum < numbers.length; secondNum++) {
				for (int thirdNum = 0; thirdNum < numbers.length; thirdNum++) {
					for (int fourthNum = 0; fourthNum < numbers.length; fourthNum++) {
						if (checkNumbers(firstNum, secondNum, thirdNum, fourthNum)) {
							String leftSide = "" + numbers[firstNum] + numbers[secondNum];
							String rightSide = "" + numbers[thirdNum] + numbers[fourthNum];
							if (leftSide.equals(rightSide)) {
								System.out.println("" + numbers[firstNum] + "|" + numbers[secondNum]
										+ "==" + numbers[thirdNum] + "|" + numbers[fourthNum]);
								resultFound = true;
							}
						}
					}
				}
			}
		}
		
		if (!resultFound) {
			System.out.println("No");
		}
	}

	private static boolean checkNumbers(int first, int second, int third, int fourth) {

		return numbers[first] != numbers[second] && numbers[first] != numbers[third]
				&& numbers[first] != numbers[fourth]
				&& numbers[second] != numbers[third] && numbers[second] != numbers[fourth]
				&& numbers[third] != numbers[fourth];
	}
}
