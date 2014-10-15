package JavaSyntax;

import java.util.Scanner;

public class Pr09PointsInsideTheHouse {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		double x = scan.nextDouble();
		double y = scan.nextDouble();
		
		boolean inside = false;
		
		if (x >= 12.5 && x <= 17.5 && y >= 8.5 && y <= 13.5) {
			inside = true;
		}
		else if (x >= 20 && x <= 22.5 && y >= 8.5 && y <= 13.5) {
			inside = true;
		}
		else {
			double[] pointA = {12.5, 8.5};
			double[] pointB = {22.5, 8.5};
			double[] pointC = {17.5, 3.5};
			double[] pointP = {x, y};
			
			double triangleArea = CalculateArea(pointA, pointB, pointC);
			double area1 = CalculateArea(pointP, pointA, pointB);
			double area2 = CalculateArea(pointP, pointB, pointC);
			double area3 = CalculateArea(pointP, pointA, pointC);
			
			if (triangleArea == area1 + area2 + area3) {
				inside = true;
			}
		}
		
		if (inside) {
			System.out.println("inside");
		}
		else {
			System.out.println("outside");
		}
	}

	private static double CalculateArea(double[] pointA, double[] pointB,
			double[] pointC) {
	
		// abs((x1*(y2-y3) + x2*(y3-y1)+ x3*(y1-y2))/2.0)
		
		return Math.abs((pointA[0]*(pointB[1] - pointC[1]) +
				pointB[0]*(pointC[1] - pointA[1]) +
				pointC[0]*(pointA[1] - pointB[1])) / 2);
	}

}
