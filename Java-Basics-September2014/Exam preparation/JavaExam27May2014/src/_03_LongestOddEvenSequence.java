import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;


public class _03_LongestOddEvenSequence {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("[() ]+");
		input = clean(input);
		int largestCount = 1;
		int currentCount = 1;
		for (int currIndex = 0; currIndex < input.length; currIndex++) {
			
			for (int nextIndex = currIndex + 1; nextIndex < input.length; nextIndex++) {
				int lastNum = Integer.parseInt(input[nextIndex - 1]);
				int currentNum = Integer.parseInt(input[nextIndex]);
				
				if (lastNum % 2 == 0 && (currentNum % 2 == 1 || currentNum % 2 == -1)) {
					currentCount++;
				} else if ((lastNum % 2 == 1 || lastNum % 2 == -1) && currentNum % 2 == 0) {
					currentCount++;
				} else if (lastNum == 0 || currentNum == 0) {
					currentCount++;
				} else {
					break;
				}
			}
			
			if (largestCount < currentCount) {
				largestCount = currentCount;
			}
			currentCount = 1;
		}
		
		System.out.println(largestCount);
	}
	
	public static String[] clean(final String[] v) {
	    ArrayList<String> list = new ArrayList<String>(Arrays.asList(v));
	    list.remove(0);
	    return list.toArray(new String[list.size()]);
	}

}
