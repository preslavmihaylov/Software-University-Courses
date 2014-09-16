import java.util.Arrays;
import java.util.Scanner;


public class _01_SortArrayOfNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int countOfInputs = scan.nextInt();
		
		int[] numbers = new int[countOfInputs];
		
		for (int index = 0; index < numbers.length; index++) {
			int input = scan.nextInt();
			
			numbers[index] = input;
		}
		
		Arrays.sort(numbers);
		
		for (int number : numbers) {
			System.out.print(number + " ");
		}
	}

}
