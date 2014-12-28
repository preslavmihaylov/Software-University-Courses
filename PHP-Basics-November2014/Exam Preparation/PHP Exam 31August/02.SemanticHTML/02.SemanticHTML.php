<?php

// $_GET['html'] = '<p class = "section" >
//     <div style = "border: 1px" id = "header" >
//         Header
//         <div id = "nav" >
//             Nav
//         </div>   <!--   nav   -->
//     </div>  <!--header-->
//   </p> <!-- end paragraph section -->
// ';
//
// $_GET['html'] = '<div id="  class"    a   =  "asd"        href = "asdsa" style=" border: 1px; color: red;"     >
// </div     > <!-- header -->
// ';
//
// $_GET['html'] = '<div style="color:red" id="header">
// </div> <!-- header -->
// ';
//
// $_GET['html'] = '<div align="left" id="nav" style="color:blue">
//   <ul class="header">
//     <li id="main">
//       Hi, I have id="main".
//     </li>
//   </ul>
// </div> <!-- nav -->
// ';

$html = $_GET['html'];

$html = preg_replace_callback('/<div(.*)(class|id)\s*=\s*\"\s*([^"\s]+)\s*\"(.*)>/', function($matches) {
    return preg_replace('/\s+/', ' ', $matches[0]);
},
$html);
$html = preg_replace('/<div\s*(\s[a-z].*[^\s])?\s*(class|id)\s*=\s*\"\s*([^"\s]+)\s*\"\s*(\s[a-z].*[^\s])?\s*>/', '<$3$1$4>', $html);
$html = preg_replace('/<\/div\s*>\s*<\!--\s*([a-z]+)\s*-->/', '</$1>', $html);
// var_dump($html);
echo $html;
