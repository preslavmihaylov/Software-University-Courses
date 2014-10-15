package JavaSyntax;

import java.util.Scanner;

public class Pr03PointsInsideFigure {

	public static void main(String[] args) {
		boolean left = false;
		boolean right = false;
		boolean top = false;
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		double x = scan.nextDouble();
		double y = scan.nextDouble();
		
		if (x <= 17.5 && x >= 12.5 && y >= 8.5 && y <= 13.5) {
			left = true;
		}
		else if (x <= 22.5 && x >= 20 && y >= 8.5 && y <= 13.5) {
			right = true;
		}
		else if (x <= 22.5 && x >= 12.5 && y >= 6 && y <= 8.5) {
			top = true;
		}
		
		if (top || right || left) {
			System.out.println("inside");
		}
		else {
			System.out.println("outside");
		}
	}

}
