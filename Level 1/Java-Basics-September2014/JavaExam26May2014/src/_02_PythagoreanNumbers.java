import java.util.Scanner;


public class _02_PythagoreanNumbers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		int numCount = scan.nextInt();
		int[] numbers = new int[numCount];
		boolean resultFound = false;
		
		for (int index = 0; index < numbers.length; index++) {
			int input = scan.nextInt();
			numbers[index] = input;
		}
		
		for (int first = 0; first < numbers.length; first++) {
			for (int second = 0; second < numbers.length; second++) {
				for (int third = 0; third < numbers.length; third++) {
					if (numbers[first] <= numbers[second] && 
							numbers[first] * numbers[first] 
									+ numbers[second] * numbers[second]
											== numbers[third] * numbers[third]) {
						
						resultFound = true;
						System.out.println(numbers[first] + "*" + numbers[first] 
								+ " + " + numbers[second] + "*" + numbers[second]
										+ " = " + numbers[third] + "*" + numbers[third]);
					}
				}
			}
		}
		
		if (!resultFound) {
			System.out.println("No");
		}
	}

}
