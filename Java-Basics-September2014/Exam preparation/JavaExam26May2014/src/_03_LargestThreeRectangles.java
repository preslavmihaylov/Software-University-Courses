import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;


public class _03_LargestThreeRectangles {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("[\\[\\]x ]+");
		input = clean(input);
		
		int[][] rectangles = new int[input.length / 2][2];
		
		int rowCount = 0;
		int colCount = -1;
		
		for (int index = 0; index < input.length; index++) {
			colCount++;
			rectangles[rowCount][colCount] = Integer.parseInt(input[index]);
			if (index % 2 == 1) {
				rowCount++;
				colCount = -1;
			}
		}
		
		int largestArea = Integer.MIN_VALUE;
		for (int row = 0; row < rectangles.length - 2; row++) {
			int firstArea = rectangles[row][0] * rectangles[row][1];
			int secondArea = rectangles[row + 1][0] * rectangles[row + 1][1];
			int thirdArea = rectangles[row + 2][0] * rectangles[row + 2][1];
			
			if (firstArea + secondArea + thirdArea > largestArea) {
				largestArea = firstArea + secondArea + thirdArea;
			}
		}
		
		System.out.println(largestArea);
		
		
	}
	
	public static String[] clean(final String[] v) {
	    ArrayList<String> list = new ArrayList<String>(Arrays.asList(v));
	    list.remove(0);
	    return list.toArray(new String[list.size()]);
	}

}
