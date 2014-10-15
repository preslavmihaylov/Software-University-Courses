package JavaSyntax;

import java.util.Scanner;

public class Pr05DecimalToHexadecimal {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int number = scan.nextInt();
		
		String hexValue = Integer.toHexString(number);
		
		System.out.println(hexValue.toUpperCase());
	}

}
