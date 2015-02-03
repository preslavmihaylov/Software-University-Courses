
import java.util.Locale;
import java.util.Scanner;


public class _05_AngleUnitConverter {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in).useLocale(Locale.US);
		
		
		int numOfInputs = scan.nextInt();
		
		for (int index = 0; index < numOfInputs; index++) {
			double input = scan.nextDouble();
			String measure = scan.next();
			
			if (measure.equals("rad")) {
				ConvertToDegrees(input);
			}
			else {
				ConvertToRadians(input);
			}
		}
	}

	private static void ConvertToDegrees(double input) {
		System.out.println("Result:");
		System.out.printf("%.6f", (180 * input) / Math.PI);
		System.out.println();
		
	}

	private static void ConvertToRadians(double input) {
		System.out.println("Result:");
		System.out.printf("%.6f", input * Math.PI / 180);
		System.out.println();
	}

}
