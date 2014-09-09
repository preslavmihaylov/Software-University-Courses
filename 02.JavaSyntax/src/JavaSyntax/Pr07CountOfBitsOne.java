package JavaSyntax;

import java.util.Scanner;

public class Pr07CountOfBitsOne {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int number = scan.nextInt();
		int result = Integer.bitCount(number);
		System.out.println(result);
		
	}

}
