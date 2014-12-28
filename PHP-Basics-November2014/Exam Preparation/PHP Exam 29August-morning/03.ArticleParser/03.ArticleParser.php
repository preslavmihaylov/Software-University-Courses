<?php

//$_GET['text'] = 'Ttile%Mr. a.; 26-03-1981-elements of a document or visual presentation. Replacing meaningful content that could be distracting with placeholder text may allow viewers to focus on graphic aspects such as font, typography, and page layout.. Ttirle%Mr. a.; 26-12-1985 -elements of a document or visual presentation. Replacing meaningful content that could be distracting with placeholder text may allow viewers to focus on graphic aspects such as font, typography, and page layout.. Ttsile%Mr. a.; 26-01-1983 -elements of a document or visual presentation. Replacing meaningful content that could be distracting with placeholder text may allow viewers to focus on graphic aspects such as font, typography, and page layout.. ztile%...;26-03-1982 - e/*mails';


date_default_timezone_set('Europe/Sofia');
$text = $_GET['text']; // !!! htmlspecialchars?
$pattern = '/([a-zA-Z\s\-]+)\%([a-zA-Z\s\.\-]+)\;\s*(\d{2}-\d{2}-\d{4})\s*\-([^\n]+)/';
preg_match_all($pattern, $text, $matches);

// var_dump($matches);

for ($index = 0; $index < count($matches[0]); $index++) {
    $topic = trim($matches[1][$index]);
    $author = trim($matches[2][$index]);
    $date = date_create_from_format('d-m-Y', trim($matches[3][$index]));
    $month = date_format($date, 'F');

    $content = substr(trim(htmlspecialchars($matches[4][$index])), 0, 100);

    $content .= "...";

    $output = "<div>\n<b>Topic:</b> <span>$topic</span>\n" .
        "<b>Author:</b> <span>$author</span>\n" .
        "<b>When:</b> <span>$month</span>\n" .
        "<b>Summary:</b> <span>$content</span>\n" .
        "</div>\n";
    echo $output;
}


// <div>
// <b>Topic:</b> <span>The dangers of smoking</span>
// <b>Author:</b> <span>Dr. Elliot Hawking</span>
// <b>When:</b> <span>June</span>
// <b>Summary:</b> <span>Recent research has proven that about 80% of all smokers, who smoke on a regular daily basis, are de...</span>
// </div>
