<?php

$text = $_GET['text'];
$blacklist = preg_split('/[\s]+/', $_GET['blacklist']);

for ($index = 0; $index < count($blacklist); $index++) {
    $blacklist[$index] = preg_replace('/\./', '\.', $blacklist[$index]);
    $blacklist[$index] = preg_replace('/\*(.*)/', '.*$1$', $blacklist[$index]);
    if (!preg_match('/\*/', $blacklist[$index])) {
        $blacklist[$index] = '^' . $blacklist[$index] . '$';
    }
}

$text = preg_replace_callback(
    '/[0-9a-zA-Z\+\-\_]+@[0-9a-zA-Z\–]+\.[0-9a-zA-Z\-\.]+/',
    function ($matches) use ($blacklist) {
        foreach ($blacklist as $ban) {
            $pattern = '/' . $ban . '/';
            preg_match($pattern, $matches[0], $match);
            if (count($match) > 0) {
                $replacement = array_fill(0, strlen($matches[0]), "*");
                return implode($replacement);
            }
        }

        return '<a href="mailto:' . $matches[0] . '">' . $matches[0] . '</a>';
        // return strtolower($matches[0]);
    },
    $text
);

echo '<p>' . $text . '</p>';