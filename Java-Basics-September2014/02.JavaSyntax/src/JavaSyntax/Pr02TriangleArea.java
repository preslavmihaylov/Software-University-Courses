package JavaSyntax;

import java.util.Scanner;

public class Pr02TriangleArea {

	public static void main(String[] args) {
		int[][] points = new int[3][2];
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		for (int index = 0; index < 3; index++) {
			points[index][0] = scan.nextInt();
			points[index][1] = scan.nextInt();
		}
		
		double triangleArea = points[0][0] * (points[1][1] - points[2][1]) +
				points[1][0] * (points[2][1] - points[0][1]) +
				points[2][0] * (points[0][1] - points[1][1]);
		triangleArea /= 2;
		
		System.out.printf("The triangle area is %.0f", Math.abs(triangleArea));
	}

}
