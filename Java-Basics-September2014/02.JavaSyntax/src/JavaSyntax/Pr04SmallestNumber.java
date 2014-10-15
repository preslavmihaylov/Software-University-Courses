package JavaSyntax;

import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class Pr04SmallestNumber {

	public static void main(String[] args) {
		Locale.setDefault(Locale.US); 
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		double minNumber = Double.MAX_VALUE;
		
		double[] numbers = new double[3];
		
		for (int index = 0; index < numbers.length; index++) {
			numbers[index] = scan.nextDouble();
		}
		
		for (int index = 0; index < numbers.length; index++) {
			if (numbers[index] < minNumber) {
				minNumber = numbers[index];
			}
		}
		
		DecimalFormat df = new DecimalFormat("###.#");
		System.out.println("The minimal number is " + df.format(minNumber));
		
		
	}

}
