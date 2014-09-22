import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class _03_BiggestThreePrimeNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split("\\D+");
		ArrayList<Integer> primeNumbers = new ArrayList<>();
		
		for (int i = 1; i < input.length; i++) {
			int currentNum = Integer.parseInt(input[i]);
			
			boolean checkPrime = isPrime(currentNum);
			
			if (checkPrime && !primeNumbers.contains(currentNum)) {
				primeNumbers.add(currentNum);
			}
		}
		
		Collections.sort(primeNumbers);
		
		if (primeNumbers.size() >= 3) {
			int result = 0;
			for (int i = primeNumbers.size() - 1; i >= primeNumbers.size() - 3; i--) {
				result += primeNumbers.get(i);
			}
			
			System.out.println(result);
		} else {
			System.out.println("No");
		}
	}

	private static boolean isPrime(int currentNum) {
		for (int i = 2; i <= Math.sqrt(currentNum); i++) {
			if (currentNum % i == 0) {
				return false;
			}
		}
		
		if (currentNum <= 1) {
			return false;
		}
		
		return true;
	}

}
