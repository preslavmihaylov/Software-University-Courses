import java.util.Scanner;


public class _01_SymmetricNumbersInRange {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int num1 = scan.nextInt();
		int num2 = scan.nextInt();
		
		for (int index = num1; index <= num2; index++) {
			String currentNum = Integer.toString(index);
			boolean symmetric = false;
			
			/* check the first and last digit of the number. 
			 In case it contains 1 digit it is symmetric */
			if (currentNum.length() > 1) {
				if (currentNum.charAt(0) == currentNum.charAt(currentNum.length() - 1)) {
					symmetric = true;
				}
			}
			else {
				symmetric = true;
			}
			
			if (symmetric) {
				System.out.print(currentNum + " ");
			}
		}
	}

}
