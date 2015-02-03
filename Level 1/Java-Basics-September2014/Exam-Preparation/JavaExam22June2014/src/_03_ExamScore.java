import java.util.Locale;
import java.util.Scanner;
import java.util.TreeMap;


public class _03_ExamScore {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input;
		
		Locale.setDefault(Locale.US);
		
		for (int ignoreLines = 0; ignoreLines < 3; ignoreLines++) {
			input = scan.nextLine();
		}
		
		input = scan.nextLine();
		
		TreeMap<Integer, TreeMap<String, Double>> data = new TreeMap<>();
		
		while (!input.matches("[\\-]+")) {
			String[] elements = input.split("[| ]+");
			
			// [0] - nothing; [1] - firstName; [2] - familyName; [3] - examScore; [4] - grade;
			
			TreeMap<String, Double> check = data.get(Integer.parseInt(elements[3]));
			if (check == null) {
				check = new TreeMap<String, Double>();
			}
			
			check.put("" + elements[1] + " " + elements[2], Double.parseDouble(elements[4]));
			data.put(Integer.parseInt(elements[3]), check);
			
			input = scan.nextLine();
		}
		
		for (Integer score : data.keySet()) {
			System.out.print(score + " -> ");
			TreeMap<String, Double> students = data.get(score);
			System.out.print(students.keySet() + "; ");
			
			double averageScore = 0;
			int gradesCount = 0;
			for (Double grade : students.values()) {
				averageScore += grade;
				gradesCount++;
			}
			
			averageScore /= (double) gradesCount;
			
			System.out.printf("avg=%.2f", averageScore);
			System.out.println();
		}
		
	}

}
