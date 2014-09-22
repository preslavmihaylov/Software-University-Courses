import java.util.Scanner;


public class AddingAngles {
	
	public static void main(String[] args) {
		
		// read the input for number of angles and actual angles
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		int[] angles = new int[n];
		for (int i = 0; i < angles.length; i++) {
			angles[i] = str.nextInt();
		}
		
		// iterate over the array to find the matching sum
		int count = 0;
		for (int i = 0; i < angles.length; i++) {
			for (int j = i + 1; j < angles.length; j++) {
				for (int k = j + 1; k < angles.length; k++) {
					int a = angles[i];
					int b = angles[j];
					int c = angles[k];
					int sum = a + b + c;
					if (sum % 360 == 0) {
						System.out.printf("%d + %d + %d = %d degrees\n",
								a, b, c, sum);
						count++;
					}
				}
			}
		}
		
		//print "No" if there is no matching sum
		if (count == 0) {
			System.out.println("No");
		}
	}
}
