package JavaSyntax;

import java.util.Scanner;

public class Pr08CountOfEqualBitPairs {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int number = scan.nextInt();
		int count = 0;
		
		while (number > 0) {
			int bit = number & 1;
			number >>= 1;
			int nextBit = number & 1;
			
			if (bit == nextBit) {
				count++;
			}
		}
		
		System.out.println(count);
	}

}
