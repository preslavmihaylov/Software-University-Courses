import java.util.Scanner;


public class _02_SumCards {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split(" ");
		int[] numbers = new int[input.length];
		
		for (int i = 0; i < input.length; i++) {
			switch (input[i].charAt(0)) {
			case '1':
				numbers[i] = 10;
				break;
			case 'J':
				numbers[i] = 12;
				break;
			case 'Q':
				numbers[i] = 13;
				break;
			case 'K':
				numbers[i] = 14;
				break;
			case 'A':
				numbers[i] = 15;
				break;
			default:
				numbers[i] = Integer.parseInt(Character.toString(input[i].charAt(0)));
				break;
			}
		}
			
		
		int totalWeight = 0;
		int currentWeight = 0;
		
		int lastNum = Integer.MIN_VALUE;
		boolean doubled = false;
		
		
		for (int i = 0; i < numbers.length; i++) {
			if (lastNum == numbers[i]) {
				doubled = true;
				currentWeight += numbers[i];
			} else {
				if (doubled) {
					totalWeight += currentWeight * 2;
					currentWeight = numbers[i];
					doubled = false;
				} else {
					totalWeight += currentWeight;
					currentWeight = numbers[i];
				}
			}
			
			lastNum = numbers[i];
		}
		
		if (doubled) {
			totalWeight += currentWeight * 2;
		} else {
			totalWeight += numbers[numbers.length - 1];
		}
		
		System.out.println(totalWeight);
	}
}
