package JavaSyntax;

import java.util.Scanner;

public class Pr01RectangleArea {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int width = scan.nextInt();
		int height = scan.nextInt();
		
		System.out.println(width * height);
	}

}
