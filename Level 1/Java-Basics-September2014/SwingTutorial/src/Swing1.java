import java.awt.Dimension;
import java.awt.Toolkit;
import javax.swing.*;

public class Swing1 extends JFrame {

	public static void main(String[] args) {
		
		new Swing1();
	}
	
	public Swing1() {
		
		// basic settings
		this.setSize(400, 400);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel thePanel = new JPanel();
		
		Toolkit toolKit = Toolkit.getDefaultToolkit();
		Dimension dimensions = toolKit.getScreenSize();
		
		int xPos = (dimensions.width / 2) - (this.getWidth() / 2);
		int yPos = (dimensions.height / 2) - (this.getHeight() / 2);
		
		this.setLocation(xPos, yPos);
		
		// content of the frame
		
		this.setTitle("My First Frame");
		
		JLabel label1 = new JLabel("Something random");
		
		label1.setText("Something randommer");
		
		JButton newButton = new JButton("This is a button");
		
		newButton.setToolTipText("This is just a button");
		
		JTextField randomTextField = new JTextField("Type something", 10);
		
		JTextArea randomTextArea = new JTextArea(15, 20);
		
		randomTextArea.setText("This is a text area with a "
				+ "very long and important text in it\n");
		randomTextArea.setLineWrap(true);
		randomTextArea.setWrapStyleWord(true);
		
		int numOfLines = randomTextArea.getLineCount();
		randomTextArea.append("number of lines: " + numOfLines);
		
		JScrollPane scrollbar = new JScrollPane(randomTextArea, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
		
		thePanel.add(label1);
		thePanel.add(newButton);
		thePanel.add(randomTextField);
		thePanel.add(scrollbar);
		
		this.add(thePanel);
		this.setVisible(true);
		
		randomTextField.requestFocus();
	}

}
