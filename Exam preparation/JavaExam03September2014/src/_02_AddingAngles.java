import java.util.Scanner;


public class _02_AddingAngles {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int inputCount = scan.nextInt();
		int[] degrees = new int[inputCount];
		boolean resultFound = false;
		
		for (int i = 0; i < inputCount; i++) {
			degrees[i] = scan.nextInt();
		}
		
		for (int first = 0; first < degrees.length; first++) {
			for (int second = first + 1; second < degrees.length; second++) {
				for (int third = second + 1; third < degrees.length; third++) {
					int result = degrees[first] + degrees[second] + degrees[third];
					
					if (result % 360 == 0) {
						resultFound = true;
						System.out.println(degrees[first] + " + " + degrees[second] + " + "
								+ degrees[third] + " = " + result + " degrees");
					}
				}
			}
		}
		
		if (!resultFound) {
			System.out.println("No");
		}
	}

}
