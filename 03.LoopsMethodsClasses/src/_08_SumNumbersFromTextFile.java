import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;


public class _08_SumNumbersFromTextFile {
	
	public static void main(String[] args) throws IOException {
		
		@SuppressWarnings("resource")
		BufferedReader reader = new BufferedReader(new FileReader(
				"_08_SumNumbersFromFile.txt"));
		String line = null;
		int result = 0;
		while ((line = reader.readLine()) != null) {
		    result += Integer.parseInt(line);
		}
		
		if (result != 0) {
			System.out.println(result);
		}
		else {
			System.out.println("Error");
		}
	}
}
