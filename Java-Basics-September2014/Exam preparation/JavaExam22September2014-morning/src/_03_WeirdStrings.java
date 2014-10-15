import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;


public class _03_WeirdStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("[/\\)(| ]+");
		
		String junkWordsRemoved = "";
		for (String string : input) {
			junkWordsRemoved += string;
		}
		
		input = junkWordsRemoved.split("[^a-zA-Z]");
		
		ArrayList<Integer> weights = new ArrayList<>();
		String regex = "[a-zA-Z]+";
		
		for (int i = 0; i < input.length; i++) {
			if (!input[i].matches(regex)) {
				input = clean(input, i);
				i--;
			}
		}
		
		for (int i = 0; i < input.length; i++) {
			String temp = input[i].toLowerCase();
			int tempNumber = 0;
			
			for (int j = 0; j < temp.length(); j++) {
				tempNumber += temp.charAt(j) - 96;
			}
			
			weights.add(tempNumber);
			
		}
		
		int biggestSum = Integer.MIN_VALUE;
		int firstIndex = 0;
		int secondIndex = 0;
		
		for (int index = 0; index < weights.size() - 1; index++) {
			if (weights.get(index) + weights.get(index + 1) >= biggestSum) {
				biggestSum = weights.get(index) + weights.get(index + 1);
				firstIndex = index;
				secondIndex = index + 1;
			}
		}
		
		System.out.println(input[firstIndex]);
		System.out.println(input[secondIndex]);
		
	}
	
	public static String[] clean(final String[] v, int index) {
	    ArrayList<String> list = new ArrayList<String>(Arrays.asList(v));
	    list.remove(index);
	    return list.toArray(new String[list.size()]);
	}

	
	// (a)bc||de|f: (Hello)3 '' |(soap|Box)rAc|e=(somnambulSkiGiganti)
	// (oopa)+(opa)..(opa)+(opa)|nqkoiMi (*&sa NaHaKa""vStopa)
}
