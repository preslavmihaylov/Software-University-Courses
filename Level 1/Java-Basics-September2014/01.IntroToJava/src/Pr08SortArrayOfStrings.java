import java.util.Arrays;
import java.util.Scanner;


public class Pr08SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int numOfInputs = Integer.parseInt(scan.nextLine());
		String[] cities = new String[numOfInputs];
		
		for (int index = 0; index < numOfInputs; index++) {
			cities[index] = scan.nextLine();
		}
		
		scan.close();
		Arrays.sort(cities);

		for (String city : cities) {
			System.out.println(city);
		}
	}

}
