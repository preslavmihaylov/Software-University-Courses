import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;


public class _13_WebCrawler {

	static int levelsCount;
	static ArrayList<String> urls = new ArrayList<>();
	
	public static void main(String[] args) throws IOException {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String inputUrl = scan.next();
		levelsCount = scan.nextInt();
		
		attemptConnection(inputUrl, 0);
		
		PrintWriter out = new PrintWriter("D:\\Programming\\Java-Basics-September2014\\"
				+ "04.JavaCollectionsBasics\\_13_WebCrawlerOutput.txt");
		
		for (String url : urls) {
			out.println(url);
		}
		out.close();
	}
	
	public static void webCrawl(String url, int count) throws IOException {
		
		if (count == levelsCount) {
			return;
		}
		
		Document doc = Jsoup.connect(url).get();

		Elements links = doc.getElementsByAttribute("href");
		
		for (Element link : links) {
			String linkHref = link.attr("href");
			
			if (linkHref.matches("/+[-a-zA-Z0-9+&@#/%=~_|!:,;]+")) {
				linkHref = url + linkHref;
			}
			
			if (!urls.contains(linkHref)) {
				if (linkHref.matches("\\b(https?|ftp|file)://[-a-zA-Z0-9+&@#/%=~_|!:,.;]*"
						+ "[-a-zA-Z0-9+&@#/%=~_|]")) {
				    urls.add(linkHref);
				    attemptConnection(linkHref, count + 1);
				}
			}
		}
	}
	
	public static void attemptConnection(String url, int count) {
		
		try {
			webCrawl(url, count);
		} catch (Exception e) {
			System.out.println("Couldn't open " + url);
			return;
		}
	}

}
