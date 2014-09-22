import java.util.ArrayList;
import java.util.Scanner;


public class _02_MagicSum {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int divider = Integer.parseInt(scan.nextLine());
		
		String command = scan.nextLine();
		ArrayList<Integer> numbers = new ArrayList<>();
		boolean resultFound = false;
		
		while (!command.equals("End")) {
			numbers.add(Integer.parseInt(command));
			command = scan.nextLine();
		}
		
		int magicSum = Integer.MIN_VALUE;
		String output = "";
		
		for (int first = 0; first < numbers.size(); first++) {
			for (int second = first + 1; second < numbers.size(); second++) {
				for (int third = second + 1; third < numbers.size(); third++) {
					int sum = numbers.get(first) + numbers.get(second) + numbers.get(third);
					
					if (sum % divider == 0 && magicSum < sum) {
						magicSum = sum;
						output = "(" + numbers.get(first) + " + " + numbers.get(second) + " + " +
								numbers.get(third) + ") % " + divider + " = 0";
						resultFound = true;
					}
				}
			}
		}
		
		if (!resultFound) {
			System.out.println("No");
		} else {
			System.out.println(output);
		}
		
	}

}
