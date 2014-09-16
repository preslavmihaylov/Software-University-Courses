import java.util.Scanner;


public class _05_CountAllWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("[\\W]+");
		
		int count = input.length;
		
		System.out.println(count);
	}

}
