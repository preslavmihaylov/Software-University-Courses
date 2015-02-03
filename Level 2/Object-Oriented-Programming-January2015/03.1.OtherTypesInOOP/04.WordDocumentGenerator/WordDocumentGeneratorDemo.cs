using System;
using Novacode;
using System.Drawing;
using System.Diagnostics;
using System.IO;

class WordDocumentGeneratorDemo
{
    static void Main()
    {
        // Modify to suit your machine:
        string fileName = @"../../wordDocument.docx";

        // Create a document in memory:
        var doc = DocX.Create(fileName);

        var format = new Formatting();
        format.FontFamily = new FontFamily("Arial Black");
        format.Size = 18D;
        format.Position = 20;

        // Insert a paragrpah:
        Paragraph heading = doc.InsertParagraph("SoftUni OOP Game Contest", false, format);

        heading.Alignment = Alignment.center;
        InsertPicture(doc, @"../../rpg-game.png", format);

        format.FontFamily = new FontFamily("Arial");
        format.Size = 10;
        format.Position = 5;

        doc.InsertParagraph();

        Paragraph second = doc.InsertParagraph("SoftUni is organizing a contest for the best ", false, format);
        format.Bold = true;
        second.InsertText("role playing game ", false, format);
        format.Bold = false;
        second.InsertText("from the OOP teamwork projects. The winning teams will receive a ", false, format);
        format.UnderlineColor = Color.Black;
        format.Bold = true;
        second.InsertText("grand prize!", false, format);

        format.Bold = false;
        format.UnderlineColor = Color.Transparent;
        Paragraph third = doc.InsertParagraph("The game should be:", false, format);
 
        var numberedList = doc.AddList("", 1, ListItemType.Bulleted);
        doc.AddListItem(numberedList, "Properly structured and follow all good OOP practices");
        doc.AddListItem(numberedList, "Awesome");
        doc.AddListItem(numberedList, "...Very awesome!");
        doc.InsertList(numberedList);

        doc.InsertParagraph();
        Table table = doc.AddTable(4, 3);
        table.Rows[0].TableHeader = true;

        format.Position = -5;

        for (int rows = 0; rows < 4; rows++)
        {
            for (int cols = 0; cols < 3; cols++)
            {
                table.Rows[rows].Cells[cols].Width = 300;
                Paragraph currentParagraph = null;
                if (rows == 0)
                {
                    table.Rows[rows].Cells[cols].FillColor = Color.CadetBlue;
                    switch (cols)
                    {
                        case 0:
                            currentParagraph = table.Rows[rows].Cells[cols].InsertParagraph("Team");
                            break;
                        case 1:
                            currentParagraph = table.Rows[rows].Cells[cols].InsertParagraph("Game");
                            break;
                        default:
                            currentParagraph = table.Rows[rows].Cells[cols].InsertParagraph("Points");
                            break;
                    }
                }
                else
                {
                    currentParagraph = table.Rows[rows].Cells[cols].InsertParagraph("-");
                }

                currentParagraph.Alignment = Alignment.center;
            }
        }
        doc.InsertTable(table);
        doc.InsertParagraph();

        format.Size = 10;
        Paragraph fourth = doc.InsertParagraph("The top 3 teams with receive a ", false , format);
        fourth.Alignment = Alignment.center;

        format.Bold = true;
        fourth.InsertText("SPECTACULAR", false, format);
        format.Bold = false;
        fourth.InsertText(" prize:", false, format);

        format.Size = 18;
        format.FontColor = Color.CadetBlue;
        format.Bold = true;
        format.UnderlineColor = Color.CadetBlue;
        Paragraph final = doc.InsertParagraph("A HANDSHAKE FROM NAKOV", false, format);
        final.Alignment = Alignment.center;

        // Save to the output directory:
        doc.Save();

        // Open in Word:
        Process.Start("WINWORD.EXE", fileName);
    }

    private static void InsertPicture(DocX doc, string filename, Formatting format)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            System.Drawing.Image myImg = System.Drawing.Image.FromFile(filename);

            myImg.Save(memoryStream, myImg.RawFormat);  // Save your picture in a memory stream.
            memoryStream.Seek(0, SeekOrigin.Begin);

            Novacode.Image img = doc.AddImage(memoryStream); // Create image.

            Paragraph p = doc.InsertParagraph("", false);

            Picture pic1 = img.CreatePicture();     // Create picture.

            p.InsertPicture(pic1, 0); // Insert picture into paragraph.

            doc.Save();
        }
    }
}
