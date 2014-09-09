package JavaSyntax;

import java.util.Scanner;

public class Pr06FormattingNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int num1 = scan.nextInt();
		double num2 = scan.nextDouble();
		double num3 = scan.nextDouble();
		
		System.out.format("|%-10s|%010d|%10.2f|%-10.3f|"
				, Integer.toHexString(num1).toUpperCase()
				, Integer.parseInt(Integer.toBinaryString(num1))
				, num2
				, num3);
	}

}
