import java.awt.Dimension;
import java.awt.Toolkit;

import javax.swing.*;

import java.awt.event.*;

public class Swing2 extends JFrame {

	JButton button1;
	JTextField textField1;
	JTextArea textArea1;
	int buttonClicked;
	
	public static void main(String[] args) {
		
		new Swing2();
		
	}
	
	public Swing2() {
		
		// basics settings
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
		
		this.setTitle("My Second Frame");
		
		button1 = new JButton("Click Here");
		
		ListenForButton lForButton = new ListenForButton();
		
		button1.addActionListener(lForButton);
		
		thePanel.add(button1);
		textField1 = new JTextField("", 15);
		
		ListenForKeys lForKeys = new ListenForKeys();
		
		textField1.addKeyListener(lForKeys);
		
		thePanel.add(textField1);
		
		textArea1 = new JTextArea(15, 20);
		textArea1.setText("Tracking Events\n");
		textArea1.setLineWrap(true);
		textArea1.setWrapStyleWord(true);
		
		JScrollPane scrollbar = new JScrollPane(textArea1, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
		
		thePanel.add(scrollbar);
		
		ListenForWindow lForWindow = new ListenForWindow();
		
		this.addWindowListener(lForWindow);
		
		ListenForMouse lForMouse = new ListenForMouse();
		
		thePanel.addMouseListener(lForMouse);
		
		this.add(thePanel);
		
		this.setVisible(true);
	}
	
	private class ListenForButton implements ActionListener {
		
		public void actionPerformed(ActionEvent e) {
			if (e.getSource() == button1) {
				buttonClicked++;
				textArea1.append("Button clicked " + buttonClicked + "times\n");
				
				//e.getSource().toString();
			}
		}
		
	}
	
	private class ListenForKeys implements KeyListener {

		@Override
		public void keyPressed(KeyEvent e) {
			textArea1.append("Key Hit:" + e.getKeyChar() + "\n");
			
		}

		@Override
		public void keyReleased(KeyEvent arg0) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void keyTyped(KeyEvent arg0) {
			// TODO Auto-generated method stub
			
		}
		
		
	}
	
	private class ListenForWindow implements WindowListener {

		@Override
		public void windowActivated(WindowEvent e) {
			textArea1.append("Window is active\n");
			
		}

		@Override
		public void windowClosed(WindowEvent arg0) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void windowClosing(WindowEvent arg0) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void windowDeactivated(WindowEvent arg0) {
			textArea1.append("Window is not active\n");
			
		}

		@Override
		public void windowDeiconified(WindowEvent arg0) {
			textArea1.append("Window is in Normal State\n");
			
		}

		@Override
		public void windowIconified(WindowEvent arg0) {
			textArea1.append("Window is minimized\n");
			
		}

		@Override
		public void windowOpened(WindowEvent arg0) {
			textArea1.append("Window is created\n");
			
		}
		
	}
	
	private class ListenForMouse implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			textArea1.append("Mouse Panel pos: " + e.getX() + " " + e.getY() + "\n");
			textArea1.append("Mouse Screen pos: " + e.getXOnScreen() + " " + e.getYOnScreen() + "\n");
			textArea1.append("Mouse Button " + e.getButton() + "\n");
			textArea1.append("Mouse Clicks: " + e.getClickCount() + "\n");
			
		}

		@Override
		public void mouseEntered(MouseEvent arg0) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void mouseExited(MouseEvent arg0) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void mousePressed(MouseEvent arg0) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
			// TODO Auto-generated method stub
			
		}
		
	}

}
