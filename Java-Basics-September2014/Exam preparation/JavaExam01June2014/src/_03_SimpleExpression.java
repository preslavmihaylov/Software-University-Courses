import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;


public class _03_SimpleExpression {
	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String input = scan.nextLine();
		
		String regex = "[ \\+\\-]+";
		
		String[] numbers = input.split(regex);
		
		regex = "[0-9 \\.]+";
		
		String[] symbols = input.split(regex);
		
		if (numbers[0].equals("")) {
			numbers = clean(numbers);
		}
		
		if (symbols[0].equals("")) {
			symbols = clean(symbols);
		}
		
		BigDecimal result = new BigDecimal(numbers[0]);
		
		for (int i = 0; i < numbers.length - 1; i++) {
			BigDecimal currentNum = new BigDecimal(numbers[i + 1]);
			if (symbols[i].equals("-")) {
				result = result.subtract(currentNum);
			} else {
				result = result.add(currentNum);
			}
		}
		
		System.out.println(result);
	}
	
	public static String[] clean(final String[] v) {
	    ArrayList<String> list = new ArrayList<String>(Arrays.asList(v));
	    list.remove(0);
	    return list.toArray(new String[list.size()]);
	}
}
