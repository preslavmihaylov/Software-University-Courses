import javax.swing.*;

import java.awt.event.*;

public class Swing4 extends JFrame {

	JComboBox favouriteShows;
	JButton button1;
	String infoOnComponent = "";
	
	public static void main(String[] args) {
		new Swing4();

	}
	
	public Swing4() {
		
		this.setSize(400, 400);
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(EXIT_ON_CLOSE);
		this.setTitle("My Fourth Frame");
		
		JPanel thePanel = new JPanel();
		
		String[] shows = {"Breaking Bad", "Life on Mars", "Doctor Who"};
		
		favouriteShows = new JComboBox(shows);
		favouriteShows.addItem("Pushing Daisies");
		
		button1 = new JButton("Get Answer");
		
		ListenForButtons lForButton = new ListenForButtons();
		button1.addActionListener(lForButton);
		
		thePanel.add(button1);
		thePanel.add(favouriteShows);
		this.add(thePanel);
		this.setVisible(true);
		
		favouriteShows.insertItemAt("Dexter", 1);
		
		favouriteShows.setMaximumRowCount(3);
		
		favouriteShows.removeItem("Dexter");
		
		favouriteShows.removeItemAt(1);
	}
	
	private class ListenForButtons implements ActionListener {

		public void actionPerformed(ActionEvent e) {
			
			if (e.getSource() == button1) {
				favouriteShows.setEditable(true);
				
				infoOnComponent += "Item at 0:" + favouriteShows.getItemAt(0) + "\n";
				infoOnComponent += "Number of shows:" + favouriteShows.getItemCount() + "\n";
				infoOnComponent += "Selected ID:" + favouriteShows.getSelectedIndex() + "\n";
				infoOnComponent += "Selected Value:" + favouriteShows.getSelectedItem() + "\n";
				infoOnComponent += "Are Editable:" + favouriteShows.isEditable() + "\n";
				
				JOptionPane.showMessageDialog(Swing4.this, infoOnComponent,
						"Information", JOptionPane.INFORMATION_MESSAGE);
				
				infoOnComponent = "";
			}
			
		}
		
	}

}
