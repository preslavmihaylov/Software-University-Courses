import java.util.Scanner;


public class _08_ExtractEmails {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split(" ");
		String temp = "";
		
		// in order to remove the dot at the end of each text
		for (int index = 0; index < input[input.length - 1].length() - 1; index++) {
			temp += input[input.length - 1].charAt(index);
		}
		
		input[input.length - 1] = temp;
		
		String regex = "([a-zA-Z0-9]+[.,-_]?[a-zA-Z0-9]+)+[@]{1}"
				+ "([a-zA-Z0-9]+[.-]?[a-zA-Z0-9]+)+([.]{1}[a-zA-Z0-9]+)+";
		
		for (String word : input) {
			if (word.matches(regex)) {
				System.out.println(word);
			}
		}
	}

}
